﻿using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;
using Geocaching.Interfases.Manager;
using Geocaching.Interfases.Repository;
using Geocaching.Interfases.Validator;

namespace Geocaching.BL.Manager
{
    public class UserManager<T> : Manager<T>, IUserManager<T> where T : User
    {
        private readonly IUserRepository<User> _userRepository;

        public UserManager(IUserRepository<User> userRepository, IRepository<T> repository, IValidator<T> validator)
            : base(repository, validator)
        {
            _userRepository = userRepository;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public void SentConfirmMail(T entity, string url)
        {
            MailAddress from = new MailAddress("socialnetwork.mail.service@gmail.com", "Web Registration");
            // кому отправляем
            MailAddress to = new MailAddress(entity.email);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Email confirmation";
            // текст письма - включаем в него ссылку
            m.Body = string.Format("Для завершения регистрации перейдите по ссылке:" +
                            "<a href=\"{0}\" title=\"Подтвердить регистрацию\">{0}</a>", url);
            m.IsBodyHtml = true;
            // адрес smtp-сервера, с которого мы и будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("socialnetwork.mail.service@gmail.com", "123456789poiuytrewq");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

        public void SendPassRecovery(T entity, string newPassword)
        {
            MailAddress from = new MailAddress("socialnetwork.mail.service@gmail.com", "Web Registration");
            MailAddress to = new MailAddress(entity.email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Password Recovery";
            m.Body = string.Format("Ваш пароль востановлен" + "Ваш новый пароль: " + "{0}", newPassword);
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("socialnetwork.mail.service@gmail.com", "123456789poiuytrewq");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }


        public void ActivateUser(T entity)
        {
            entity.is_activated = true;
            _userRepository.Update(entity);
            _userRepository.Save();
        }
    }
}
