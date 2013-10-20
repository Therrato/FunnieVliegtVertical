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
        public Texture2D tex;/* = new Texture2D(Screen.width, Screen.height);*/
        
        public int[] uitslag;
        //public Color[] colorArray = new Color[3]{Color.red,Color.green,Color.blue};
        public Color g;
        public Color b;

        

        void Main()
        {
           
        }
        public void sendEmail()
        {

            tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            tex.Apply();

            var bytes = tex.EncodeToPNG();
           // Destroy(tex);
            File.WriteAllBytes(Application.dataPath + "/scre/Screenshot.png", bytes);

            //Application.CaptureScreenshot(Application.dataPath + "/scre/Screenshot.png");
            //yieldfunction(10);

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("saxiontestmail@gmail.com");
            mail.To.Add("jeroen.van.dragt@gmail.com");
            mail.Subject = "Test Mail";
            mail.Body = "Hello,\n" +
                        "Here are the testresults of: " + System.DateTime.Now.ToString();
            Attachment att = new System.Net.Mail.Attachment(Application.dataPath + "/scre/Screenshot.png");
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

        public void Update()
        {
           // Color[] color = tex.GetPixels(100, 10,2,2);
            //Texture2D newTex = new Texture2D(Screen.width, Screen.height);

            //newTex.SetPixels(color);
            for (var i = 0; i < uitslag[0] *2.5f; i++)
            {
                int width = 20;
                for (var j = 0; j < width; j++)
                {
                    tex.SetPixel(j, i, g);
                    
                }
                
            }

            
            
        }

        public WaitForSeconds yieldfunction(int a)
        {
            return new WaitForSeconds(a);
        }

        public void OnGUI(/*int[] uitslag*/ )
        {
            if(GUI.Button(new Rect(500, 10, 100, 100), "apply pixels"))
            {
                tex.Apply();
                //sendEmail();
            }
            GUI.DrawTexture(new Rect(50, 50, 300, 300), tex);
            if (uitslag.Length == 2)
            {
                // 1 round
            }
            else if (uitslag.Length == 10)
            {
                //round 1
                GUI.DrawTexture(new Rect(50, Screen.height - 100, 20, uitslag[0] * 2), goodGraph);
                GUI.DrawTexture(new Rect(70, Screen.height - 100, 20, uitslag[1] * 2), testGraph);

                //round 2
                GUI.DrawTexture(new Rect(100, Screen.height - 100, 20, uitslag[2] * 2), goodGraph);
                GUI.DrawTexture(new Rect(120, Screen.height - 100, 20, uitslag[3] * 2), testGraph);

                //round 3
                GUI.DrawTexture(new Rect(150, Screen.height - 100, 20, uitslag[4] * 2), goodGraph);
                GUI.DrawTexture(new Rect(170, Screen.height - 100, 20, uitslag[5] * 2), testGraph);

                //round 4
                GUI.DrawTexture(new Rect(200, Screen.height - 100, 20, uitslag[6] * 2), goodGraph);
                GUI.DrawTexture(new Rect(220, Screen.height - 100, 20, uitslag[7] * 2), testGraph);

                //round 5
                GUI.DrawTexture(new Rect(250, Screen.height - 100, 20, uitslag[8] * 2), goodGraph);
                GUI.DrawTexture(new Rect(270, Screen.height - 100, 20, uitslag[9] * 2), testGraph);
            }

        }
    }
}