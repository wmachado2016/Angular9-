using MediatR;

namespace CleanArch.Application.Notifications
{
    public class EmailNotifications: INotification
    { 
        public string Origem { get; private set; }
        public string Destino { get; private set; }
        public string Assunto { get; private set; }
        public string Mensagem { get; private set; }

        public EmailNotifications(string origem, string destino, string assunto, string mensagem)
        {
            Origem = origem;
            Destino = destino;
            Assunto = assunto;
            Mensagem = mensagem;
        }
    }
}
