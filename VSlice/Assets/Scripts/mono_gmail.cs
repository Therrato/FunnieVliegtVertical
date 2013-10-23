using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Assets.Scripts
{
    public class mono_gmail : MonoBehaviour
    {
        public Texture2D goodGraph;
        public Texture2D testGraph;
        public int percentage1 = 0;
        public int percentage2 = 0;
        public Texture2D tex;

        public string emailbody = "";


        public int[] uitslag;
        public Color g;
        public Color b;



        void Main()
        {

        }
        public void sendEmail()
        {


            var bytes = tex.EncodeToPNG();
            File.WriteAllBytes(Application.dataPath + "/Resources/Texture/Graphic emailSend.png", bytes);

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("saxiontestmail@gmail.com");
            mail.To.Add("r.schroder@live.nl");
            mail.Subject = "Test Mail";
            mail.Body = emailbody;
            Attachment att = new System.Net.Mail.Attachment(Application.dataPath + "/Resources/Texture/Graphic emailSend.png");
            //  Attachment att = new System.Net.Mail.Attachment();
            mail.Attachments.Add(att);

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("saxiontestmail@gmail.com", "projectcommercialbreak") as ICredentialsByHost;
            smtpServer.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback =
                delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };
            smtpServer.Send(mail);
            Debug.Log("success");

        }

        public void mailStart(int[] ratios, DateTime startTime, int allbananas,int allfeathers, string mosthit)
        {
            if (ratios.Length > 4)
            {
                createGraph(ratios);
                tex.Apply();
                emailbody = "Tijdens een recente vlucht zijn deze volgende scores behaald. \r\n"+
                            "Tevens hebben we de volgende gegevens uit kunnen lezen. \r\n"+
                            "De vlucht begon om "+ startTime+" \r\n"+
                            "Er zijn "+ ratios.Length/2 + " ronde(n) geweest.\r\n"+
                            "Er zijn "+ allbananas+ " bananen opgepakt in het spel.\r\n"+
                            "Er zijn "+ allfeathers+" veren opgepakt in het spel. \r\n"+
                            "De speler had de meeste moeite met het object "+mosthit+ ". \r\n"+
                            "in de bijlage kan u een grafiek zien waarop staat aangegeven in het groen hoeveel procent van de banananen er zijn opgepakt\r\n"+
                            "en in het rood word aangegeven hoeveel procent van de objecten er zijn geraakt";

                sendEmail();
                Resources.UnloadAsset(tex);
            }
        }

        public void createGraph(int[] u)
        {
            int extraOffset = 0;
            int count = 0;
            for (int i = 0; i < u.Length; i++)
            {
                
                if (count == 2)
                {
                    extraOffset += 10;
                    count = 0;
                }
                count++;
                if (i % 2 == 0)
                {
                    createBar(37 + (20 * i)+extraOffset, 41, u[i], 20, g);
                }
                else
                {
                    createBar(37 + (20 * i)+extraOffset, 41, u[i], 20, b);
                }
                Debug.Log(i+ "this is the value"+u[i]);
            }
        }

        public void createBar(int beginx, int beginY, int height, int width, Color thiscolor)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height * 2.5f; y++)
                {
                    tex.SetPixel(beginx + x, beginY + y, thiscolor);
                }

            }
        }

    }
}