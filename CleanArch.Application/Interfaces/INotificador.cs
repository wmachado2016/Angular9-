using CleanArch.Application.Notifications;
using System.Collections.Generic;

namespace CleanArch.Application.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}