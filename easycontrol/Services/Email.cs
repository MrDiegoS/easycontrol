using easycontrol.Models.Util;
using System;
using System.Net.Mail;

namespace easycontrol.Services
{
    public class Email
    {
        private readonly Hash _HASH = new Hash();

        public Email()
        {

        }

        /// <summary>ENVIA E-MAIL</summary>
        /// <param name="_EMAIL">E-MAIL PARA RECEBER A SENHA</param>
        /// <param name="_SENHA">SENHA A SER ENVIADA NO E-MAIL</param>
        /// <returns>SEM RETORNO</returns>
        public void enviaEmail(string _EMAIL, string _SENHA)
        {
            //Instância classe email
            MailMessage mail = new MailMessage();
            mail.To.Add(_EMAIL);
            mail.From = new MailAddress("central.easycontrol@gmail.com", "Atendimento EasyControl");
            mail.Subject = "Ajuda está a caminho!";
            string Body = renderBody(_HASH.Descriptografar(_SENHA));
            mail.Body = Body;
            mail.IsBodyHtml = true;

            //Instância smtp do servidor, neste caso o gmail.
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("central.easycontrol@gmail.com", "e@SyC0nTr0l");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

        /// <summary>MONTA O CORPO DO E-MAIL</summary>
        /// <param name="_HTML">MENSAGEM QUE FICARA NO CORPO DO E-MAIL</param>
        /// <returns>CORPO DO E-MAIL</returns>
        public string renderBody(string _HTML)
        {
            string _body = String.Empty;

            _body= "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional //EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" 
 +                                                      "<html xmlns='http://www.w3.org/1999/xhtml' xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:v='urn:schemas-microsoft-com:vml'>"
 +                                                      " <head>"
 +                                                      "  <meta content='text/html; charset=utf-8' http-equiv='Content-Type'/>"
 +                                                      "  <meta content='width=device-width' name='viewport'/>"
 +                                                      "  <meta content='IE=edge' http-equiv='X-UA-Compatible'/>"
 +                                                      "  <link href='https://fonts.googleapis.com/css?family=Lato' rel='stylesheet' type='text/css'/> "
 +                                                      "<style type='text/css'>"
 +                                                      "      body {"
 +                                                      "  margin: 0;"
 +                                                      "  padding: 0;"
 +                                                      "}"
 +                                                      "table,"
 +                                                      "td,"
 +                                                      "tr {"
 +                                                      "vertical-align: top;"
 +                                                      "border-collapse: collapse;"
 +                                                      "}"
 +                                                      "* {line-height: inherit;"
 +                                                      "      }"
 +                                                      "a[x-apple-data-detectors=true] {"
 +                                                      "color: inherit !important;"
 +                                                      "text-decoration: none !important;"
 +                                                      "}"
 +                                                      "</style>"
 +                                                      "<style id='media-query' type='text/css'>"
 +                                                      "@media (max-width: 500px) {"
 +                                                      "  .block-grid,"
 +                                                      "    .col {"
 +                                                      "min-width: 320px !important;"
 +                                                      "max-width: 100% !important;"
 +                                                      "display: block !important;"
 +                                                      "}"
 +                                                      "    .block-grid {"
 +                                                      "width: 100% !important;"
 +                                                      "}    "
 +                                                      ".col {"
 +                                                      "width: 100% !important;"
 +                                                      "}"
 +                                                      "    .col>div {"
 +                                                      "margin: 0 auto;"
 +                                                      "}"
 +                                                      "      img.fullwidth,"
 +                                                      "img.fullwidthOnMobile {"
 +                                                      "max-width: 100% !important;"
 +                                                      "}"
 +                                                      "    .no-stack .col {"
 +                                                      "min-width: 0 !important;"
 +                                                      "display: table-cell !important;"
 +                                                      "}"
 +                                                      "    .no-stack.two-up .col "
 +                                                      "{width: 50% !important;"
 +                                                      "}"
 +                                                      "    .no-stack .col.num4 {"
 +                                                      "width: 33% !important;"
 +                                                      "}"
 +                                                      "    .no-stack .col.num8 {"
 +                                                      "width: 66% !important;"
 +                                                      "}"
 +                                                      "    .no-stack .col.num4 {"
 +                                                      "width: 33% !important;"
 +                                                      "}"
 +                                                      "    .no-stack .col.num3 {"
 +                                                      "width: 25% !important;"
 +                                                      "}"
 +                                                      "    .no-stack .col.num6 {"
 +                                                      "width: 50% !important;"
 +                                                      "}"
 +                                                      "    .no-stack .col.num9 {"
 +                                                      "width: 75% !important;"
 +                                                      "} "
 +                                                      "    .video-block {"
 +                                                      "max-width: none !important;"
 +                                                      "}    "
 +                                                      ".mobile_hide {"
 +                                                      "min-height: 0px;"
 +                                                      "max-height: 0px;"
 +                                                      "max-width: 0px;"
 +                                                      "display: none;"
 +                                                      "overflow: hidden;"
 +                                                      "font-size: 0px;"
 +                                                      "}"
 +                                                      "    .desktop_hide {"
 +                                                      "display: block !important;"
 +                                                      "max-height: none !important;"
 +                                                      "}"
 +                                                      "}</style>"
 +                                                      "      </head>"
 +                                                      "<body class='clean-body' style='margin: 0; padding: 0; -webkit-text-size-adjust: 100%; background-color: #F5F5F5;'>"
 +                                                      "<table bgcolor='#F5F5F5' cellpadding='0' cellspacing='0' class='nl-container' role='presentation' style='table-layout: fixed; vertical-align: top; min-width: 320px; Margin: 0 auto; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #F5F5F5; width: 100%;' valign='top' width='100%'>"
 +                                                      "<tbody>"
 +                                                      "<tr style='vertical-align: top;' valign='top'>"
 +                                                      "<td style='word-break: break-word; vertical-align: top;' valign='top'>"
 +                                                      "<div style='background-color:transparent;'>"
 +                                                      "<div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 480px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: transparent;'>"
 +                                                      "<div style='border-collapse: collapse;display: table;width: 100%;background-color:transparent;'>"
 +                                                      "<div class='col num12' style='min-width: 320px; max-width: 480px; display: table-cell; vertical-align: top; width: 480px;'>"
 +                                                      "<div style='width:100% !important;'>"
 +                                                      "<div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:5px; padding-right: 0px; padding-left: 0px;'>"
 +                                                      "<table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'>"
 +                                                      "<tbody>"
 +                                                      "<tr style='vertical-align: top;' valign='top'>"
 +                                                      "<td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 10px; padding-right: 10px; padding-bottom: 10px; padding-left: 10px;' valign='top'>"
 +                                                      "<table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' height='10' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid transparent; height: 10px; width: 100%;' valign='top' width='100%'>"
 +                                                      "<tbody>"
 +                                                      "<tr style='vertical-align: top;' valign='top'>"
 +                                                      "<td height='10' style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td>"
 +                                                      "</tr>"
 +                                                      "</tbody>"
 +                                                      "</table>"
 +                                                      "</td>"
 +                                                      "</tr>"
 +                                                      "</tbody>"
 +                                                      "</table>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "<div style='background-color:transparent;'>"
 +                                                      "<div class='block-grid two-up no-stack' style='Margin: 0 auto; min-width: 320px; max-width: 480px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #FFFFFF;'>"
 +                                                      "<div style='border-collapse: collapse;display: table;width: 100%;background-color:#FFFFFF;'>"
 +                                                      "<div class='col num6' style='max-width: 320px; min-width: 240px; display: table-cell; vertical-align: top; width: 240px;'>"
 +                                                      "<div style='width:100% !important;'>"
 +                                                      "<div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:25px; padding-bottom:25px; padding-right: 0px; padding-left: 25px;'>"
 +                                                      "<div align='left' class='img-container left fixedwidth' style='padding-right: 0px;padding-left: 0px;'>"
 //+                                                     "<img alt='Image' border='0' class='left fixedwidth' src='https://uploaddeimagens.com.br/images/002/434/510/original/logo.png?1571537701' style='text-decoration: none; -ms-interpolation-mode: bicubic; border: 0; height: auto; width: 100%; max-width: 139px; display: block;' title='Image' width='139'/>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "<div class='col num6' style='max-width: 320px; min-width: 240px; display: table-cell; vertical-align: top; width: 240px;'>"
 +                                                      "<div style='width:100% !important;'>"
 +                                                      "<div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:25px; padding-bottom:25px; padding-right: 25px; padding-left: 0px;'>"
 +                                                      "<div></div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "<div style='background-color:transparent;'>"
 +                                                      "<div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 480px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #D6E7F0;'>"
 +                                                      "<div style='border-collapse: collapse;display: table;width: 100%;background-color:#D6E7F0;'>"
 +                                                      "<div class='col num12' style='min-width: 320px; max-width: 480px; display: table-cell; vertical-align: top; width: 480px;'>"
 +                                                      "<div style='width:100% !important;'>"
 +                                                      "<div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:60px; padding-right: 25px; padding-left: 25px;'>"
 +                                                      "<div align='center' class='img-container center fixedwidth' style='padding-right: 0px;padding-left: 0px;'>"
 +                                                      "<div style='font-size:1px;line-height:45px'> </div><img align='center' alt='Image' border='0' class='center fixedwidth' src='https://uploaddeimagens.com.br/images/002/434/483/original/headerBody.png?1571535754' style='text-decoration: none; -ms-interpolation-mode: bicubic; border: 0; height: auto; width: 100%; max-width: 387px; display: block;' title='Image' width='387'/>"                                                      
 +                                                      "</div>"
 +                                                      "<div style='color:#052d3d;font-family:'Lato', Tahoma, Verdana, Segoe, sans-serif;line-height:1.5;padding-top:20px;padding-right:10px;padding-bottom:0px;padding-left:15px;'>"
 +                                                      "<div style='line-height: 1.5; font-family: 'Lato', Tahoma, Verdana, Segoe, sans-serif; font-size: 12px; color: #052d3d; mso-line-height-alt: 18px;'>"
 +                                                      "<p style='line-height: 1.5; text-align: center; font-size: 38px; mso-line-height-alt: 57px; margin: 0;'><span style='font-size: 38px;'><strong>SENHA</strong></span></p>"
 +                                                      "<p style='font-size: 34px; line-height: 1.5; text-align: center; mso-line-height-alt: 51px; margin: 0;'><span style='font-size: 34px;'><strong><span style='font-size: 34px;'><span style='color: #2190e3; font-size: 34px;'>"+ _HTML + "</span></span></strong></span></p>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "<div style='color:#555555;font-family:'Lato', Tahoma, Verdana, Segoe, sans-serif;line-height:1.2;padding-top:10px;padding-right:10px;padding-bottom:10px;padding-left:10px;'>"
 +                                                      "  <div style='font-size: 12px; line-height: 1.2; font-family: 'Lato', Tahoma, Verdana, Segoe, sans-serif; color: #555555; mso-line-height-alt: 14px;'>"
 +                                                      "  <p style='font-size: 18px; line-height: 1.2; text-align: center; mso-line-height-alt: 22px; margin: 0;'><span style='font-size: 18px; color: #000000;'>Pode ficar de boa, super normal esquecer a senha, pois bem, sua senha é a que está em cima desta mensagem. Já está tudo pronto para você realizar seu login.</span></p>"
 +                                                      "  </div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</div>"
 +                                                      "</td>"
 +                                                      "</tr>"
 +                                                      "</tbody>"
 +                                                      "</table>"
 +                                                      "</body>"
 +                                                      "</html>";

            return _body;
        }
    }
}