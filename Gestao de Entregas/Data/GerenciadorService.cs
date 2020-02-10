using System.Collections.Generic;
using System.Linq;

namespace Gestao_de_Entregas.Data
{
    public class GerenciadorService
    {
        private readonly ApplicationDbContext _db;

        public GerenciadorService(ApplicationDbContext db)
        {
            _db = db;
        }

        //Operações CRUD

        //Obter todas as entregas

        public List<EntregaUrgente> ObterEntregas()
        {
            var ListaEntregas = _db.EntregaUrgente.OrderByDescending(x => x.EntregaId).ToList();

            foreach (var list in ListaEntregas)
            {
                if (list.Usuario == null)
                {
                    list.Usuario = _db.EntregaUrgente.Where(x => x.EntregaId == list.EntregaId).Select(x => x.Usuario).FirstOrDefault();
                }
            }
            return ListaEntregas;
        }

        //Inserir Entrega

        public string InserirEntrega(EntregaUrgente entregasUrgentes)
        {
            _db.EntregaUrgente.Add(entregasUrgentes);
            _db.SaveChanges();
            return "Salvo com sucesso";
        }

        // Buscar entrega pelo Id

        public EntregaUrgente ObterEntregaPorId(int id)
        {
            EntregaUrgente entregasUrgentes = _db.EntregaUrgente.FirstOrDefault(s => s.EntregaId == id);
            return entregasUrgentes;
        }

        /// <summary>
        /// Retorna Lista de entregas classificadas como urgente
        /// </summary>
        /// <returns></returns>
        public List<EntregaUrgente> ObterEntregaUrgente()
        {
            var ListaEntregas = _db.EntregaUrgente.Where(s => s.Urgente == true).ToList();
            return ListaEntregas;
        }

        //Atualizar Entrega

        public string AtualizarEntrega(EntregaUrgente entrega)
        {
            _db.EntregaUrgente.Update(entrega);
            _db.SaveChanges();
            return "Atualizado com sucesso";
        }

        public List<Coleta> ObterColeta()
        {
            var ListaColetas = _db.Coleta.OrderByDescending(x => x.ColetaId).ToList();

            foreach (var list in ListaColetas)
            {
                if (list.Usuario == null)
                {
                    list.Usuario = _db.EntregaUrgente.Where(x => x.EntregaId == list.ColetaId).Select(x => x.Usuario).FirstOrDefault();
                }
            }
            return ListaColetas;
        }

        //Inserir Entrega

        public string InserirColeta(Coleta coleta)
        {
            _db.Coleta.Add(coleta);
            _db.SaveChanges();
            return "Salvo com sucesso";
        }

        // Buscar entrega pelo Id

        public Coleta ObterColetaPorId(int id)
        {
            Coleta coleta = _db.Coleta.FirstOrDefault(s => s.ColetaId == id);
            return coleta;
        }

        /// <summary>
        /// Retorna Lista de entregas classificadas como urgente
        /// </summary>
        /// <returns></returns>
        public List<Coleta> ObterColetaFeita()
        {
            var coletado = _db.Coleta.Where(s => s.Coletado == true).ToList();
            return coletado;
        }

        //Atualizar Entrega

        public string AtualizarColeta(Coleta coleta)
        {
            _db.Coleta.Update(coleta);
            _db.SaveChanges();
            return "Atualizado com sucesso";
        }

        public string InserirFalta(Falta falta)
        {
            _db.Falta.Add(falta);
            _db.SaveChanges();
            return "Salvo com sucesso";
        }

        public List<Falta> ObterFalta()
        {
            var falta = _db.Falta.OrderByDescending(f => f.DataFalta).ToList();

            foreach (var list in falta)
            {
                if (list.Usuario == null)
                {
                    list.Usuario = _db.Falta.Where(x => x.FaltaId == list.FaltaId).Select(x => x.Usuario).FirstOrDefault();
                }
            }
            return falta;
        }

        public string AtualizarFalta(Falta falta)
        {
            _db.Falta.Update(falta);
            _db.SaveChanges();
            return "Atualizado com sucesso";
        }

        public string InserirFaltaStatus(FaltaStatus faltaStatus)
        {
            _db.FaltaStatus.Add(faltaStatus);
            _db.SaveChanges();
            return "Salvo com sucesso";
        }

        public List<FaltaStatus> ObterFaltaStatus(Falta falta)
        {
            var faltaStatus = _db.FaltaStatus.Where(fs => fs.Falta == falta).OrderByDescending(fs => fs.DataStatus).ToList();

            foreach (var list in faltaStatus)
            {
                if (list.Usuario == null)
                {
                    list.Usuario = _db.FaltaStatus.Where(x => x.Id == list.Id).Select(x => x.Usuario).FirstOrDefault();
                }
            }
            return faltaStatus;
        }

        public string InserirColetaStatus(ColetaStatus coletaStatus)
        {
            _db.ColetaStatus.Add(coletaStatus);
            _db.SaveChanges();
            return "Salvo com sucesso";
        }

        public List<ColetaStatus> ObterColetaStatus(Coleta coleta)
        {
            var coletaStatus = _db.ColetaStatus.Where(cs => cs.Coleta == coleta).OrderByDescending(cs => cs.DataStatus).ToList();

            foreach (var list in coletaStatus)
            {
                if (list.Usuario == null)
                {
                    list.Usuario = _db.ColetaStatus.Where(x => x.Id == list.Id).Select(x => x.Usuario).FirstOrDefault();
                }
            }
            return coletaStatus;
        }

        public string InserirEntregaUrgenteStatus(EntregaUrgenteStatus entregaUrgenteStatus)
        {
            _db.EntregaUrgenteStatus.Add(entregaUrgenteStatus);
            _db.SaveChanges();
            return "Salvo com sucesso";
        }

        public List<EntregaUrgenteStatus> ObterEntregaUrgenteStatus(EntregaUrgente entregaUrgente)
        {
            var entregaUrgenteStatus = _db.EntregaUrgenteStatus.Where(eus => eus.EntregaUrgente == entregaUrgente).OrderByDescending(eus => eus.DataStatus).ToList();

            foreach (var list in entregaUrgenteStatus)
            {
                if (list.Usuario == null)
                {
                    list.Usuario = _db.EntregaUrgenteStatus.Where(x => x.Id == list.Id).Select(x => x.Usuario).FirstOrDefault();
                }
            }
            return entregaUrgenteStatus;
        }

        public SortedList<string, int> ObterEstatisticasEntregas()
        {
            SortedList<string, int> estatisticas = new SortedList<string, int>();

            int total = _db.EntregaUrgente.Count();
            int entregues = _db.EntregaUrgente.Where(en => en.Entregue == true).Count();
            int naoEntregues = _db.EntregaUrgente.Where(en => en.Entregue == false).Count();
            int entreguesNoPrazo = _db.EntregaUrgente.Where(en => en.DataSolicitacao < en.DataSolicitacao.AddDays(2)).Count();
            int naoEntreguesNoPrazo = _db.EntregaUrgente.Where(en => en.DataSolicitacao > en.DataSolicitacao.AddDays(2)).Count();

            estatisticas.Add("Total:", total);
            estatisticas.Add("Entregues:", entregues);
            estatisticas.Add("Não Entregues:", naoEntregues);
            estatisticas.Add("Entregues no Prazo:", entreguesNoPrazo);
            estatisticas.Add("Não entregues no Prazo:", naoEntreguesNoPrazo);
            return estatisticas;
        }

        public SortedList<string, int> ObterEstatisticasColetas()
        {
            SortedList<string, int> estatisticas = new SortedList<string, int>();

            int total = _db.Coleta.Count();
            int coletas = _db.Coleta.Where(cl => cl.Coletado == true).Count();
            int naoColetados = _db.Coleta.Where(cl => cl.Coletado == false).Count();
            int coletadosNoPrazo = _db.Coleta.Where(cl => cl.DataSolicitacao <= cl.DataColeta).Count();
            int naoColetadosNoPrazo = _db.Coleta.Where(cl => cl.DataSolicitacao > cl.DataColeta).Count();

            estatisticas.Add("Total:", total);
            estatisticas.Add("Coletas:", naoColetados);
            estatisticas.Add("Não Coletados:", coletadosNoPrazo);
            estatisticas.Add("Coletados no Prazo:", coletadosNoPrazo);
            estatisticas.Add("Não Coletados no Prazo:", naoColetadosNoPrazo);
            return estatisticas;
        }

        public SortedList<string, int> ObterEstatisticasFaltas()
        {
            SortedList<string, int> estatisticas = new SortedList<string, int>();

            int total = _db.Falta.Count();
            int volumesFaltantes = _db.Falta.Select(f => f.VolumesFaltante).Sum();
            int encontrados = _db.Falta.Where(f => f.Encontrado == true).Count();
            int naoEncontrados = _db.Falta.Where(f => f.Encontrado == false).Count();

            estatisticas.Add("Total:", total);
            estatisticas.Add("Total de volumes faltantes:", volumesFaltantes);
            estatisticas.Add("Faltas solucionadas:", encontrados);
            estatisticas.Add("Faltas não solucionadas:", naoEncontrados);

            return estatisticas;
        }

        public List<Coleta> Obter8Coletas()
        {
            var ultimaColeta = _db.Coleta.OrderBy(c => c.ColetaId).ToList().Last();
            var coleta = _db.Coleta.OrderByDescending(c => c.DataColeta).Where(c => c.ColetaId > ultimaColeta.ColetaId - 8).ToList();
            return coleta;
        }

        public List<EntregaUrgente> Obter8Entregas()
        {
            var ultimaEntrega = _db.EntregaUrgente.OrderBy(c => c.EntregaId).ToList().Last();
            var entregas = _db.EntregaUrgente.OrderByDescending(c => c.EntregaId).Where(c => c.EntregaId > ultimaEntrega.EntregaId - 8).ToList();
            return entregas;
        }
    }
}