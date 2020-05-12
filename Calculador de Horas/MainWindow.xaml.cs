﻿using Calculador_de_Horas.Database;
using Calculador_de_Horas.Entities;
using Biblioteca_padrao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Calculador_de_Horas
{
    /// <summary>
    /// Interface Principal
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Contrutor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            VerificaCadastroEmpresa();
            PreencheComboBox();
        }

        /* ************************** Metodos responsaveis pela exibição da tela ************************** */

        /// <summary>
        /// Atualiza os campos da janela.
        /// </summary>
        /// <param name="func">Objeto do tipo Funcionario recuperado do BD.</param>
        private List<DateTime> RefreshList(Funcionario func)
        {
            txtBlockDias.Text = "";
            txtBlockEntrada.Text = "";
            txtBlockSaidaAlmoco.Text = "";
            txtBlockRetornoAlmoco.Text = "";
            txtBlockSaida.Text = "";
            txtBlockExtras.Text = "";
            lblBancoHoras.Content = "";

            TimeSpan totalHoras = new TimeSpan();
            TimeSpan totalBancoHoras = new TimeSpan();
            DateTime selecionada = DPdata.SelectedDate.Value;
            int fechamento = TranferenciaDados.Empresa.DiaFechamento;

            using (MyDatabaseContext dbContext = new MyDatabaseContext())
            {
                List<HorasFuncionario> horas;
                List<DateTime> datasComRegistros = new List<DateTime>();

                DateTime selecionadaBuscaInicio;
                DateTime selecionadaBuscaFim;

                if (selecionada.Day >= fechamento)
                {
                    if (selecionada.Month == 12)
                    {
                        selecionadaBuscaInicio = new DateTime(selecionada.Year, selecionada.Month, fechamento);
                        selecionadaBuscaFim = new DateTime(selecionada.Year + 1, 1, fechamento - 1);
                    }
                    else
                    {
                        selecionadaBuscaInicio = new DateTime(selecionada.Year, selecionada.Month, fechamento);
                        selecionadaBuscaFim = new DateTime(selecionada.Year, selecionada.Month + 1, fechamento - 1);
                    }
                }
                else
                {
                    if (selecionada.Month == 1)
                    {
                        selecionadaBuscaInicio = new DateTime(selecionada.Year - 1, 12, fechamento);
                        selecionadaBuscaFim = new DateTime(selecionada.Year, selecionada.Month, fechamento - 1);
                    }
                    else
                    {
                        selecionadaBuscaInicio = new DateTime(selecionada.Year, selecionada.Month - 1, fechamento);
                        selecionadaBuscaFim = new DateTime(selecionada.Year, selecionada.Month, fechamento - 1);
                    }
                }

                horas = dbContext.BuscaCartaoPonto(func, selecionadaBuscaFim, selecionadaBuscaInicio);

                List<BancoDeHoras> bancoDeHoras = dbContext.BuscaBancoDeHoras(func);

                StringBuilder dias = new StringBuilder();
                StringBuilder entradas = new StringBuilder();
                StringBuilder saidaAlmoco = new StringBuilder();
                StringBuilder retornoAlmoco = new StringBuilder();
                StringBuilder saidas = new StringBuilder();
                StringBuilder extras = new StringBuilder();

                foreach (HorasFuncionario h in horas)
                {
                    dias.AppendLine(h.DataRegistro.ToShortDateString());
                    datasComRegistros.Add(h.DataRegistro);
                    entradas.AppendLine($"{h.Entrada.ToString()}");
                    saidaAlmoco.AppendLine($"{h.AlmocoSaida.ToString()}");
                    retornoAlmoco.AppendLine($"{h.AlmocoRetorno.ToString()}");
                    saidas.AppendLine($"{h.Saida.ToString()}");
                    extras.AppendLine($"{h.Extras.ToString()}");
                    totalHoras += h.Extras;
                    TranferenciaDados.UltimaHoraAdicionada = h;
                }

                txtBlockDias.Text = dias.ToString();
                txtBlockEntrada.Text = entradas.ToString();
                txtBlockSaidaAlmoco.Text = saidaAlmoco.ToString();
                txtBlockRetornoAlmoco.Text = retornoAlmoco.ToString();
                txtBlockSaida.Text = saidas.ToString();
                txtBlockExtras.Text = extras.ToString();

                foreach (BancoDeHoras h in bancoDeHoras)
                {
                    totalBancoHoras += h.HorasExtras;
                }

                TimeSpan totalHoraAlmoco = func.HoraAlmocoRetorno.Subtract(func.HoraAlmocoSaida);
                TimeSpan horaTrabalho = func.HoraTermino.Subtract(func.HoraIncio).Subtract(totalHoraAlmoco);
                TimeSpan totalHorasFolga = new TimeSpan();

                lblBancoHoras.Content = totalBancoHoras;
                lblTotalExtras.Content = totalHoras.ToString();

                if (totalBancoHoras >= horaTrabalho)
                {
                    while (totalBancoHoras >= horaTrabalho)
                    {
                        totalHorasFolga = totalHorasFolga.Add(new TimeSpan(1, 0, 0, 0));
                        totalBancoHoras = totalBancoHoras.Subtract(horaTrabalho);
                    }
                }
                else if (totalBancoHoras <= -horaTrabalho)
                {
                    while (totalBancoHoras <= -horaTrabalho)
                    {
                        totalHorasFolga = totalHorasFolga.Subtract(new TimeSpan(1, 0, 0, 0));
                        totalBancoHoras = totalBancoHoras.Add(horaTrabalho);
                    }
                }

                lblHoraFolga.Content = $"{totalHorasFolga.Days} Dia(s) e {totalBancoHoras.Hours} Horas";
                if (totalHorasFolga.Days >= 0 && totalHorasFolga.Hours >= 0)
                {
                    lblHoraFolga.Foreground = Brushes.Black;
                }
                else
                {
                    lblHoraFolga.Foreground = Brushes.Red;
                }
                return datasComRegistros;
            }
        }

        /// <summary>
        /// Popula as comboBox da Janela.
        /// </summary>
        private void PreencheComboBox()
        {
            List<string> Horas = new List<string> { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" };
            List<string> HorasE = new List<string> { "-23", "-22", "-21", "-20", "-19", "-18", "-17", "-16", "-15", "-14", "-13", "-12", "-11", "-10", "-09", "-08", "-07", "-06", "-05", "-04", "-03", "-02","-01",
                "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"};
            List<string> Minutos = new List<string> { "00","01","02","03","04","05","06","07","08","09","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29",
                "30","31","32","33","34","35","36","37","38","39","40","41","42","43","44","45","46","47","48","49","50","51","52","53","54","55","56","57","58","59"};

            cbHoraExtras.ItemsSource = HorasE;
            cbHoraSaidaAlmoco.ItemsSource = cbHoraRetornoAlmoco.ItemsSource = cbHoraEntrada.ItemsSource = cbHoraSaida.ItemsSource = Horas;
            cbMinutosSaidaAlmoco.ItemsSource = cbMinutosRetornoAlmoco.ItemsSource = cbMinutosEntrada.ItemsSource = cbMinutosSaida.ItemsSource = cbMinutosExtras.ItemsSource = Minutos;

            DPdata.SelectedDate = DateTime.Now;
        }

        /* ************************** Metodos de manipulação de dados ************************** */

        /// <summary>
        /// Verifica se existe empresa cadastrada
        /// </summary>
        private void VerificaCadastroEmpresa()
        {
            using (MyDatabaseContext dbContext = new MyDatabaseContext())
            {
                Empresa empresa;

                try
                {
                    empresa = dbContext.BuscarEmpresa();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                if (empresa != null)
                {
                    JanelaPrincipal.Title = $"Calculador de Horas - {empresa.RazaoSocial}";
                    TranferenciaDados.Empresa = empresa;
                }
                else
                {
                    NovaEmpresaWindow windows;
                    bool decisao = false;

                    do
                    {
                        windows = new NovaEmpresaWindow();

                        windows.ShowDialog();

                        if (windows.Empresa == null)
                        {
                            if (MessageBox.Show("Empresa não cadastrada, deseja voltar e completar o cadastro?", "Empresa não Cadastrada", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                            {
                                decisao = true;
                            }
                            else
                            {
                                decisao = false;
                                Close();
                            }
                        }
                        else
                        {
                            JanelaPrincipal.Title = $"Calculador de Horas - {windows.Empresa.RazaoSocial}";
                            TranferenciaDados.Empresa = windows.Empresa;
                        }
                    } while (decisao);
                }
            }
        }

        /// <summary>
        /// Recupera um funcionario do BD.
        /// </summary>
        private void BuscarFuncionario()
        {
            try
            {
                if (txtRegistro.Text != "")
                {
                    TranferenciaDados.Registro = int.Parse(txtRegistro.Text);
                }
                else
                {
                    ListarFuncionariosWindow windows = new ListarFuncionariosWindow();
                    windows.ShowDialog();
                    txtRegistro.Text = TranferenciaDados.Registro.ToString();
                    if (txtRegistro.Text == "")
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            using (MyDatabaseContext dbContext = new MyDatabaseContext())
            {
                Funcionario funcionario;

                try
                {
                    funcionario = dbContext.BuscarFuncionario(int.Parse(txtRegistro.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                if (funcionario != null)
                {
                    txtNome.Content = funcionario.Nome;
                    btnBancoHoras.IsEnabled = true;
                    btnDeletar.IsEnabled = true;
                    btnFechar.IsEnabled = true;
                    RefreshList(funcionario);
                    TranferenciaDados.Funcionario = funcionario;
                }
                else
                {
                    GestaoDeFuncionarioWindow windows = new GestaoDeFuncionarioWindow(txtRegistro.Text);
                    windows.ShowDialog();
                    txtRegistro.Text = TranferenciaDados.Registro.ToString();
                    btnBancoHoras.IsEnabled = false;
                    btnDeletar.IsEnabled = false;
                    btnFechar.IsEnabled = false;
                }
            }
        }

        /// <summary>
        /// Metodo para editar hora
        /// </summary>
        /// <param name="dataBtnAdicionar">Data a ser editada</param>
        private void EditarHora(DateTime dataBtnAdicionar)
        {
            EditarHorasWindow editarUltimo = new EditarHorasWindow(dataBtnAdicionar);
            editarUltimo.ShowDialog();
            RefreshList(TranferenciaDados.Funcionario);
        }

        /* ************************** Eventos de Click em botões ************************** */

        /// <summary>
        /// Evento click do botão adicionar, esse é o principal botão da interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            DateTime dataSelecionada = DPdata.SelectedDate.Value;

            try
            {
                using (MyDatabaseContext dbContext = new MyDatabaseContext())
                {
                    Funcionario funcionario = dbContext.BuscarFuncionario(int.Parse(txtRegistro.Text));
                    List<DateTime> cartaoPonto = RefreshList(funcionario);

                    if (cbMinutosExtras.SelectedIndex != 0 || cbHoraExtras.SelectedIndex != 23)
                    {
                        if (MessageBox.Show("Deseja incluir hora extra manualmente?", "Confirmar Inclusão de Horas", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            int hora = int.Parse(cbHoraExtras.SelectionBoxItem.ToString());
                            int minutos = hora < 0 ? -int.Parse(cbMinutosExtras.SelectionBoxItem.ToString()) : int.Parse(cbMinutosExtras.SelectionBoxItem.ToString());

                            TimeSpan HorasExtras = new TimeSpan(hora, minutos, 0);
                            funcionario.AtualizarBancoHoras(new BancoDeHoras(HorasExtras, "Hora Adicionada Manualmente", dataSelecionada));
                            dbContext.UpdateBanco(funcionario);

                            RefreshList(funcionario);
                        }

                        cbHoraExtras.SelectedIndex = 23;
                        cbMinutosExtras.SelectedIndex = 0;
                        return;
                    }

                    TimeSpan entrada = new TimeSpan(int.Parse(cbHoraEntrada.SelectionBoxItem.ToString()), int.Parse(cbMinutosEntrada.SelectionBoxItem.ToString()), 0);
                    TimeSpan saida = new TimeSpan(int.Parse(cbHoraSaida.SelectionBoxItem.ToString()), int.Parse(cbMinutosSaida.SelectionBoxItem.ToString()), 0);

                    TimeSpan almocoSaida = new TimeSpan(int.Parse(cbHoraSaidaAlmoco.SelectionBoxItem.ToString()), int.Parse(cbMinutosSaidaAlmoco.SelectionBoxItem.ToString()), 0);
                    if (almocoSaida == new TimeSpan(0, 0, 0))
                    {
                        almocoSaida = funcionario.HoraAlmocoSaida;
                    }

                    TimeSpan retornoAlmoco = new TimeSpan(int.Parse(cbHoraRetornoAlmoco.SelectionBoxItem.ToString()), int.Parse(cbMinutosRetornoAlmoco.SelectionBoxItem.ToString()), 0);
                    if (retornoAlmoco == new TimeSpan(0, 0, 0))
                    {
                        retornoAlmoco = funcionario.HoraAlmocoRetorno;
                    }

                    TimeSpan totalHoraAlmoco = funcionario.HoraAlmocoRetorno.Subtract(funcionario.HoraAlmocoSaida);
                    TimeSpan horaTrabalho = funcionario.HoraTermino.Subtract(funcionario.HoraIncio).Subtract(totalHoraAlmoco);

                    HorasFuncionario horas = new HorasFuncionario { Entrada = entrada, Saida = saida, AlmocoSaida = almocoSaida, AlmocoRetorno = retornoAlmoco, DataRegistro = dataSelecionada };

                    if (cartaoPonto.Contains(horas.DataRegistro))
                    {
                        if (MessageBox.Show("Já existe registro com essa data, deseja alterar?", "Hora Existente", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            EditarHora(dataSelecionada);
                        }
                    }
                    else if (dataSelecionada.DayOfWeek.ToString().ToUpper().Equals("SATURDAY") || dataSelecionada.DayOfWeek.ToString().ToUpper().Equals("SUNDAY"))
                    {
                        if (MessageBox.Show($"Proximo registro é { (dataSelecionada.DayOfWeek.ToString() == "Saturday" ? "Sabado" : "Domingo") } confirma a inclusão?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            if (entrada == new TimeSpan(0, 0, 0))
                            {
                                almocoSaida = new TimeSpan(0, 0, 0);
                                retornoAlmoco = new TimeSpan(0, 0, 0);
                            }

                            horas = new HorasFuncionario { Entrada = entrada, Saida = saida, AlmocoSaida = almocoSaida, AlmocoRetorno = retornoAlmoco, DataRegistro = dataSelecionada };
                            horas.CalculaExtras(new TimeSpan(0, 0, 0)); //Horario de trabalho em branco pois não há expediente normal.
                            funcionario.AddMarcacaoPonto(horas);
                        }
                        else
                        {
                            horas = new HorasFuncionario { Entrada = new TimeSpan(0, 0, 0), AlmocoSaida = new TimeSpan(0, 0, 0), AlmocoRetorno = new TimeSpan(0, 0, 0), Saida = new TimeSpan(0, 0, 0), DataRegistro = dataSelecionada };
                            horas.CalculaExtras(new TimeSpan(0, 0, 0));
                            funcionario.AddMarcacaoPonto(horas);
                        }
                    }
                    else
                    {
                        if (cbHoraEntrada.SelectedIndex == 0 && cbMinutosEntrada.SelectedIndex == 0 && cbHoraSaida.SelectedIndex == 0 && cbMinutosEntrada.SelectedIndex == 0)
                        {
                            switch (MessageBox.Show("Não foi informado hora de entrada e saida para esse funcionario.\nSelecione Sim para marcar como falta total.\nSelecione Não para falta justificada.", "Verificar Falta", MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
                            {
                                case MessageBoxResult.Yes:
                                    horas.AlmocoSaida = new TimeSpan(0, 0, 0);
                                    horas.AlmocoRetorno = new TimeSpan(0, 0, 0);

                                    horas.CalculaExtras(horaTrabalho);
                                    break;

                                case MessageBoxResult.No:
                                    TimeSpan extras = horas.CalculaExtras(new TimeSpan(0, 0, 0));
                                    funcionario.AtualizarBancoHoras(new BancoDeHoras(extras, $"Falta abonada em {DateTime.Now.ToShortDateString()}", dataSelecionada));
                                    dbContext.UpdateBanco(funcionario);
                                    break;

                                case MessageBoxResult.Cancel:
                                    return;
                            }
                        }
                        else if (cbHoraEntrada.SelectedIndex == 0 && cbMinutosEntrada.SelectedIndex == 0)
                        {
                            if (MessageBox.Show("Não foi informado hora de entrada para esse funcionario.\nDeseja marcar como falta parcial?", "Verificar Falta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                if (horas.AlmocoRetorno != funcionario.HoraAlmocoRetorno)
                                {
                                    horas.AlmocoRetorno = new TimeSpan(0, 0, 0);
                                    horas.AlmocoSaida = new TimeSpan(0, 0, 0);
                                    horas.Entrada = retornoAlmoco;
                                    horas.CalculaExtras(horaTrabalho);
                                }
                                else
                                {
                                    MessageBox.Show("Existe campos em branco!");
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        else if (cbHoraSaida.SelectedIndex == 0 && cbMinutosSaida.SelectedIndex == 0)
                        {
                            if (MessageBox.Show("Não foi informado hora de saida para esse funcionario\nDeseja marcar como falta parcial?", "Verificar Falta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                if (horas.AlmocoSaida != funcionario.HoraAlmocoSaida)
                                {
                                    horas.AlmocoRetorno = new TimeSpan(0, 0, 0);
                                    horas.AlmocoSaida = new TimeSpan(0, 0, 0);
                                    horas.Saida = almocoSaida;
                                    horas.CalculaExtras(horaTrabalho);
                                }
                                else
                                {
                                    MessageBox.Show("Existe campos em branco!");
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            horas.CalculaExtras(horaTrabalho);

                            if (horas.Extras <= new TimeSpan(0, 10, 0) && horas.Extras >= new TimeSpan(0, -10, 0))
                            {
                                horas.Extras = new TimeSpan(0, 0, 0);
                            }
                        }

                        funcionario.AddMarcacaoPonto(horas);
                    }

                    dbContext.UpdateFuncionario(funcionario);
                    RefreshList(funcionario);
                    DPdata.SelectedDate = dataSelecionada.AddDays(1);
                }
            }
            catch (FormatException)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Evento click do botão atualizar campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            BuscarFuncionario();
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan totalExtras = new TimeSpan(
                int.Parse(lblTotalExtras.Content.ToString().Substring(0, 2)),
                int.Parse(lblTotalExtras.Content.ToString().Substring(3, 2)),
                0);

            using (MyDatabaseContext myDatabase = new MyDatabaseContext())
            {
                FechamentoMes fechamento = new FechamentoMes
                {
                    DataFechamento = new DateTime(DPdata.SelectedDate.Value.Year, DPdata.SelectedDate.Value.Month, TranferenciaDados.Empresa.DiaFechamento),
                    Funcionario = myDatabase.BuscarFuncionario(int.Parse(txtRegistro.Text)),
                    TotalHoraMes = totalExtras
                };

                if (MessageBox.Show($"Confirma o fechamento da folha do mês {fechamento.DataFechamento.Month}/{fechamento.DataFechamento.Year} com total de {totalExtras.ToString().Substring(0, 5)} ?", "Confirmar fechamento", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    myDatabase.AdicionarFechamento(fechamento);
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Evento click do botão detalhar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetalhar_Click(object sender, RoutedEventArgs e)
        {
            GestaoDeFuncionarioWindow windows = new GestaoDeFuncionarioWindow(txtRegistro.Text);
            windows.ShowDialog();
            BuscarFuncionario();
        }

        /// <summary>
        /// Evento click do botão banco de horas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBancoHoras_Click(object sender, RoutedEventArgs e)
        {
            DateTime dataBusca = new DateTime(DPdata.SelectedDate.Value.Year, DPdata.SelectedDate.Value.Month, TranferenciaDados.Empresa.DiaFechamento);
            BancoDeHorasWindow bancoDeHorasWindow = new BancoDeHorasWindow(int.Parse(txtRegistro.Text.ToString()), dataBusca);
            bancoDeHorasWindow.ShowDialog();
        }

        /// <summary>
        /// Evento click botão Buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            txtRegistro.Text = "";
            BuscarFuncionario();
        }

        /* ************************** Eventos de troca nas comboBox ************************** */

        /// <summary>
        /// Quando troca o valor do campo Hora Entrada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbHoraEntrada_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbHoraEntrada.SelectedIndex != 0)
            {
                cbHoraExtras.IsEnabled = false;
                cbMinutosExtras.IsEnabled = false;
                cbHoraExtras.SelectedIndex = 23;
                cbMinutosExtras.SelectedIndex = 0;
            }
            else if (cbHoraRetornoAlmoco.SelectedIndex == 0 && cbHoraSaidaAlmoco.SelectedIndex == 0 &&
                cbMinutosEntrada.SelectedIndex == 0 && cbHoraSaida.SelectedIndex == 0 &&
                cbHoraEntrada.SelectedIndex == 0 && cbMinutosRetornoAlmoco.SelectedIndex == 0 &&
                cbMinutosSaida.SelectedIndex == 0 && cbMinutosSaidaAlmoco.SelectedIndex == 0)
            {
                cbHoraExtras.IsEnabled = true;
                cbMinutosExtras.IsEnabled = true;
            }
        }

        /// <summary>
        /// Quando troca o valor do campo Minuto Entrada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbMinutosEntrada_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbMinutosEntrada.SelectedIndex != 0)
            {
                cbHoraExtras.IsEnabled = false;
                cbMinutosExtras.IsEnabled = false;
                cbHoraExtras.SelectedIndex = 23;
                cbMinutosExtras.SelectedIndex = 0;
            }
            else if (cbHoraRetornoAlmoco.SelectedIndex == 0 && cbHoraSaidaAlmoco.SelectedIndex == 0 &&
                cbMinutosEntrada.SelectedIndex == 0 && cbHoraSaida.SelectedIndex == 0 &&
                cbHoraEntrada.SelectedIndex == 0 && cbMinutosRetornoAlmoco.SelectedIndex == 0 &&
                cbMinutosSaida.SelectedIndex == 0 && cbMinutosSaidaAlmoco.SelectedIndex == 0)
            {
                cbHoraExtras.IsEnabled = true;
                cbMinutosExtras.IsEnabled = true;
            }
        }

        /// <summary>
        /// Quando troca o valor do campo Hora Saida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbHoraSaida_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbHoraSaida.SelectedIndex != 0)
            {
                cbHoraExtras.IsEnabled = false;
                cbMinutosExtras.IsEnabled = false;
                cbHoraExtras.SelectedIndex = 23;
                cbMinutosExtras.SelectedIndex = 0;
            }
            else if (cbHoraRetornoAlmoco.SelectedIndex == 0 && cbHoraSaidaAlmoco.SelectedIndex == 0 &&
                cbMinutosEntrada.SelectedIndex == 0 && cbHoraSaida.SelectedIndex == 0 &&
                cbHoraEntrada.SelectedIndex == 0 && cbMinutosRetornoAlmoco.SelectedIndex == 0 &&
                cbMinutosSaida.SelectedIndex == 0 && cbMinutosSaidaAlmoco.SelectedIndex == 0)
            {
                cbHoraExtras.IsEnabled = true;
                cbMinutosExtras.IsEnabled = true;
            }
        }

        /// <summary>
        /// Quando troca o valor do campo Minuto Saida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbMinutosSaida_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbMinutosSaida.SelectedIndex != 0)
            {
                cbHoraExtras.IsEnabled = false;
                cbMinutosExtras.IsEnabled = false;
                cbHoraExtras.SelectedIndex = 23;
                cbMinutosExtras.SelectedIndex = 0;
            }
            else if (cbMinutosEntrada.SelectedIndex == 0 && cbHoraSaida.SelectedIndex == 0 && cbHoraEntrada.SelectedIndex == 0)
            {
                cbHoraExtras.IsEnabled = true;
                cbMinutosExtras.IsEnabled = true;
            }
        }

        /// <summary>
        /// Deleta o registro que tiver a mesma data que a selecionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeletar_Click(object sender, RoutedEventArgs e)
        {
            using (MyDatabaseContext dbContext = new MyDatabaseContext())
            {
                Funcionario funcionario = dbContext.BuscarFuncionario(TranferenciaDados.Registro);
                HorasFuncionario horasFuncionario = dbContext.BuscarRegistro(funcionario, DPdata.SelectedDate.Value);

                if (MessageBox.Show("Deseja realmente deletar?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (horasFuncionario != null)
                    {
                        if (horasFuncionario.Extras != (new TimeSpan(0, 0, 0)))
                        {
                            BancoDeHoras removerDoBancoDeHoras = new BancoDeHoras(-horasFuncionario.Extras, "Registro deletado", horasFuncionario.DataRegistro);
                            funcionario.AtualizarBancoHoras(removerDoBancoDeHoras);
                            dbContext.UpdateBanco(funcionario);
                        }
                        else
                        {
                            BancoDeHoras JustificativaBancoDeHoras = new BancoDeHoras(new TimeSpan(0, 0, 0), "Registro deletado", horasFuncionario.DataRegistro);
                            funcionario.AtualizarBancoHoras(JustificativaBancoDeHoras);
                            dbContext.UpdateBanco(funcionario);
                        }

                        dbContext.RemoveHora(funcionario, DPdata.SelectedDate.Value);
                        RefreshList(funcionario);

                        horasFuncionario = dbContext.BuscarRegistro(funcionario, DPdata.SelectedDate.Value);
                        if (horasFuncionario == null)
                        {
                            MessageBox.Show("Registro deletado com sucesso!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não há registros na data selecionada!");
                    }
                }
            }
        }

        private void cbMinutosSaidaAlmoco_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbMinutosSaidaAlmoco.SelectedIndex != 0)
            {
                cbHoraExtras.IsEnabled = false;
                cbMinutosExtras.IsEnabled = false;
                cbHoraExtras.SelectedIndex = 23;
                cbMinutosExtras.SelectedIndex = 0;
            }
            else if (cbHoraRetornoAlmoco.SelectedIndex == 0 && cbHoraSaidaAlmoco.SelectedIndex == 0 &&
                cbMinutosEntrada.SelectedIndex == 0 && cbHoraSaida.SelectedIndex == 0 &&
                cbHoraEntrada.SelectedIndex == 0 && cbMinutosRetornoAlmoco.SelectedIndex == 0 &&
                cbMinutosSaida.SelectedIndex == 0 && cbMinutosSaidaAlmoco.SelectedIndex == 0)
            {
                cbHoraExtras.IsEnabled = true;
                cbMinutosExtras.IsEnabled = true;
            }
        }

        private void cbHoraSaidaAlmoco_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbHoraSaidaAlmoco.SelectedIndex != 0)
            {
                cbHoraExtras.IsEnabled = false;
                cbMinutosExtras.IsEnabled = false;
                cbHoraExtras.SelectedIndex = 23;
                cbMinutosExtras.SelectedIndex = 0;
            }
            else if (cbHoraRetornoAlmoco.SelectedIndex == 0 && cbHoraSaidaAlmoco.SelectedIndex == 0 &&
                cbMinutosEntrada.SelectedIndex == 0 && cbHoraSaida.SelectedIndex == 0 &&
                cbHoraEntrada.SelectedIndex == 0 && cbMinutosRetornoAlmoco.SelectedIndex == 0 &&
                cbMinutosSaida.SelectedIndex == 0 && cbMinutosSaidaAlmoco.SelectedIndex == 0)
            {
                cbHoraExtras.IsEnabled = true;
                cbMinutosExtras.IsEnabled = true;
            }
        }

        private void cbHoraRetornoAlmoco_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbHoraRetornoAlmoco.SelectedIndex != 0)
            {
                cbHoraExtras.IsEnabled = false;
                cbMinutosExtras.IsEnabled = false;
                cbHoraExtras.SelectedIndex = 23;
                cbMinutosExtras.SelectedIndex = 0;
            }
            else if (cbHoraRetornoAlmoco.SelectedIndex == 0 && cbHoraSaidaAlmoco.SelectedIndex == 0 &&
                cbMinutosEntrada.SelectedIndex == 0 && cbHoraSaida.SelectedIndex == 0 &&
                cbHoraEntrada.SelectedIndex == 0 && cbMinutosRetornoAlmoco.SelectedIndex == 0 &&
                cbMinutosSaida.SelectedIndex == 0 && cbMinutosSaidaAlmoco.SelectedIndex == 0)
            {
                cbHoraExtras.IsEnabled = true;
                cbMinutosExtras.IsEnabled = true;
            }
        }

        private void cbMinutosRetornoAlmoco_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbMinutosRetornoAlmoco.SelectedIndex != 0)
            {
                cbHoraExtras.IsEnabled = false;
                cbMinutosExtras.IsEnabled = false;
                cbHoraExtras.SelectedIndex = 23;
                cbMinutosExtras.SelectedIndex = 0;
            }
            else if (cbHoraRetornoAlmoco.SelectedIndex == 0 && cbHoraSaidaAlmoco.SelectedIndex == 0 &&
                cbMinutosEntrada.SelectedIndex == 0 && cbHoraSaida.SelectedIndex == 0 &&
                cbHoraEntrada.SelectedIndex == 0 && cbMinutosRetornoAlmoco.SelectedIndex == 0 &&
                cbMinutosSaida.SelectedIndex == 0 && cbMinutosSaidaAlmoco.SelectedIndex == 0)
            {
                cbHoraExtras.IsEnabled = true;
                cbMinutosExtras.IsEnabled = true;
            }
        }
    }
}