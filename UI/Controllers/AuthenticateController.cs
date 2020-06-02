using Core.Data;
using Core.Model;
using Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class AuthenticateController : Controller
    {
        // GET: Authenticate
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(User user)
        {
            try
            {
                User _user = UserCommon.GetInstance().Get(new User() { email = user.email }).FirstOrDefault();
                if (_user != null)
                {
                    if (_user.password.Equals(Cripto.GetHash(user.password)))
                    {
                        if (!_user.blocked.Equals("SIM"))
                        {
                            IncorrectAttempt(_user, true);
                            var response = _user;
                            return Json(new { retorno = "/MyAccount/Index" });
                        }
                        else
                        {
                            var response = "Usuário bloqueado!";
                            return Json(new { retorno = response });
                        }
                    }
                    else
                    {
                        if (_user.attempts == 1)
                        {
                            IncorrectAttempt(_user, false);
                            var response = "Senha incorreta! O cadastro será bloqueado na próxima tentativa errada.";
                            return Json(new { retorno = response });
                        }
                        else if (_user.attempts >= 2)
                        {
                            IncorrectAttempt(_user, false);
                            var response = "Senha incorreta! O cadastro está bloqueado.";
                            return Json(new { retorno = response });
                        }
                        else
                        {
                            IncorrectAttempt(_user, false);
                            var response = "Senha incorreta!";
                            return Json(new { retorno = response });
                        }
                    }
                }
                else
                {
                    var response = "Usuário não encontrado";
                    return Json(new { retorno = response });
                }

            }
            catch
            {
                var response = "error";
                return Json(new { retorno = response });
            }
        }

        public ActionResult ResetPassword(User user)
        {
            try
            {
                User _user = UserCommon.GetInstance().Get(user).FirstOrDefault();
                if (!_user.blocked.Equals("SIM"))
                {
                    string _newPassword = Password.Create();
                    _user.password = Cripto.GetHash(_newPassword);
                    _user.change_password = 1;

                    UserCommon.GetInstance().Update(_user);
                    string body = EmailTemplate.ResetPassword(_user.nome_user, _newPassword);
                    Email email = new Email() { recipient = _user.email, subject = "Recuperação de Senha", body = body };
                    Mail.Send(email);
                    var response = "Uma nova senha foi encaminhada por e-mail";
                    return Json(new { retorno = response });
                }
                else
                {
                    var response = "O usuário está bloqueado";
                    return Json(new { retorno = response });
                }

            }
            catch
            {
                var response = "error";
                return Json(new { retorno = response });
            }
        }

        public ActionResult ChangePassword(User user)
        {
            try
            {
                if (!String.IsNullOrEmpty(user.password))
                {
                    if (Password.StrongPassword(user.password))
                    {
                        var _user = UserCommon.GetInstance().Get(new Core.Model.User() { id_user = user.id_user }).FirstOrDefault();
                        _user.password = Cripto.GetHash(user.password);
                        _user.change_password = 0;
                        UserCommon.GetInstance().Update(_user);
                        var response = "Senha alterada";
                        return Json(new { retorno = response });
                    }
                    else
                    {
                        var response = "Senha fraca! Use letras maiúsculas e minusculas, caracteres especiais e números.";
                        return Json(new { retorno = response });
                    }
                }
                else
                {
                    var response = "Nova senha não pode ser nula!";
                    return Json(new { retorno = response });
                }
            }
            catch
            {
                var response = "error";
                return Json(new { retorno = response });
            }
        }

        public ActionResult CreateAcount(User user)
        {
            try
            {
                if (Validation.Execute(user))
                {
                    string _newPassword = Password.Create();
                    user.password = Cripto.GetHash(_newPassword);
                    user.change_password = 1;
                    user.active = "SIM";
                    user.attempts = 0;
                    user.blocked = "NÃO";
                    user.profile_id = 2;

                    UserCommon.GetInstance().Create(user);
                    string body = EmailTemplate.NewUser(user.nome_user, _newPassword);
                    Email email = new Email() { recipient = user.email, subject = "Cadastro no sistema", body = body };
                    Mail.Send(email);
                    var response = "Usuário cadastrado, uma senha de acesso foi enviada por e-mail";
                    return Json(new { retorno = response });
                }
                else
                {
                    var response = "Preencha todas as informações.";
                    return Json(new { retorno = response });
                }
            }
            catch
            {
                var response = "error";
                return Json(new { retorno = response });
            }
        }

        private void IncorrectAttempt(User user, bool reset)
        {
            if (!reset)
            {
                user.attempts = user.attempts + 1;

                if (user.attempts >= 3)
                    user.blocked = "SIM";

                UserCommon.GetInstance().Update(user);
            }
            else
            {
                user.attempts = 0;
                UserCommon.GetInstance().Update(user);
            }
        }
    }
}