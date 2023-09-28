using NegozioScarpe.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegozioScarpe.Controllers
{
    public class ScarpeController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
        public static SqlConnection conn = new SqlConnection(connectionString);
        
        // GET: Scarpe
        public ActionResult Index()
        {
            SqlCommand cmd = new SqlCommand("select * from ARTICOLI", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            List<Articolo> articoliList = new List<Articolo>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read()) 
            {
                Articolo articolo = new Articolo(
                    Convert.ToInt16(sqlDataReader["IdArticolo"]),
                    sqlDataReader["NomeArticolo"].ToString(),
                    Convert.ToDouble(sqlDataReader["PrezzoArticolo"]),
                    sqlDataReader["DescrizioneArticolo"].ToString(),
                    sqlDataReader["ImmagineCopertina"].ToString(),
                    sqlDataReader["Immagine1"].ToString(),
                    sqlDataReader["immagine2"].ToString()
                    );
                articoliList.Add( articolo );
            }
            conn.Close();

            return View(articoliList);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id) 
        {
            Articolo myArt = new Articolo();
            SqlCommand cmd = new SqlCommand("select * from ARTICOLI WHERE IdArticolo=@Id", conn);
            cmd.Parameters.AddWithValue("Id", id);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Articolo art = new Articolo(
                    Convert.ToInt16(sqlDataReader["IdArticolo"]),
                    sqlDataReader["NomeArticolo"].ToString(),
                    Convert.ToDouble(sqlDataReader["PrezzoArticolo"]),
                    sqlDataReader["DescrizioneArticolo"].ToString(),
                    sqlDataReader["ImmagineCopertina"].ToString(),
                    sqlDataReader["Immagine1"].ToString(),
                    sqlDataReader["Immagine2"].ToString()
                    );
                myArt = art;
            }
            conn.Close();
            return View(myArt);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Articolo myArt = new Articolo();
            SqlCommand cmd = new SqlCommand("select * from ARTICOLI WHERE IdArticolo=@Id", conn);
            cmd.Parameters.AddWithValue("Id", id);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Articolo art = new Articolo(
                    Convert.ToInt16(sqlDataReader["IdArticolo"]),
                    sqlDataReader["NomeArticolo"].ToString(),
                    Convert.ToDouble(sqlDataReader["PrezzoArticolo"]),
                    sqlDataReader["DescrizioneArticolo"].ToString(),
                    sqlDataReader["ImmagineCopertina"].ToString(),
                    sqlDataReader["Immagine1"].ToString(),
                    sqlDataReader["Immagine2"].ToString()
                    );
                myArt = art;
            }
            conn.Close();
            return View(myArt);

        }

        [HttpPost]
        public ActionResult Edit(Articolo art) 
        {
            if (ModelState.IsValid)
            {
                try 
                {
                    SqlCommand update = new SqlCommand("UPDATE ARTICOLI SET NomeArticolo = @NomeArticolo, PrezzoArticolo = @PrezzoArticolo, DescrizioneArticolo = @DescrizioneArticolo, ImmagineCopertina = @ImmagineCopertina, Immagine1 = @Immagine1, Immagine2 = @Immagine2 WHERE IdArticolo = @IdArticolo",conn);
                    update.Parameters.AddWithValue("@NomeArticolo", art.NomeArticolo);
                    update.Parameters.AddWithValue("@PrezzoArticolo", art.PrezzoArticolo);
                    update.Parameters.AddWithValue("@DescrizioneArticolo", art.DescrizioneArticolo);
                    update.Parameters.AddWithValue("@ImmagineCopertina", art.ImmagineCopertina);
                    update.Parameters.AddWithValue("@Immagine1", art.Immagine1);
                    update.Parameters.AddWithValue("@Immagine2", art.Immagine2);
                    update.Parameters.AddWithValue("@IdArticolo", art.Id);
                    conn.Open();
                    update.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                finally { conn.Close(); }
                TempData["MessaggioDiConferma"] = "Articolo Modificato Correttamente";
            }
            return RedirectToAction("Index");
           
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Articolo myArt = new Articolo();
            SqlCommand cmd = new SqlCommand("select * from ARTICOLI WHERE IdArticolo=@Id", conn);
            cmd.Parameters.AddWithValue("Id", id);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Articolo art = new Articolo(
                    Convert.ToInt16(sqlDataReader["IdArticolo"]),
                    sqlDataReader["NomeArticolo"].ToString(),
                    Convert.ToDouble(sqlDataReader["PrezzoArticolo"]),
                    sqlDataReader["DescrizioneArticolo"].ToString(),
                    sqlDataReader["ImmagineCopertina"].ToString(),
                    sqlDataReader["Immagine1"].ToString(),
                    sqlDataReader["Immagine2"].ToString()
                    );
                myArt = art;
            }
            conn.Close();
            return View(myArt);
        }

        [HttpPost]

        public ActionResult Delete(Articolo art)
        {
            try 
            {
                SqlCommand delete = new SqlCommand("DELETE FROM ARTICOLI WHERE IdArticolo = @IdArticolo", conn);
                delete.Parameters.AddWithValue("IdArticolo", art.Id);
                conn.Open();
                delete.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {

            }
            finally { conn.Close(); }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Admin() 
        {
            SqlCommand cmd = new SqlCommand("select * from ARTICOLI", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            List<Articolo> articoliList = new List<Articolo>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Articolo articolo = new Articolo(
                    Convert.ToInt16(sqlDataReader["IdArticolo"]),
                    sqlDataReader["NomeArticolo"].ToString(),
                    Convert.ToDouble(sqlDataReader["PrezzoArticolo"]),
                    sqlDataReader["DescrizioneArticolo"].ToString(),
                    sqlDataReader["ImmagineCopertina"].ToString(),
                    sqlDataReader["Immagine1"].ToString(),
                    sqlDataReader["immagine2"].ToString()
                    );
                articoliList.Add(articolo);
            }
            conn.Close();

            return View(articoliList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Articolo art, HttpPostedFileBase ImmagineCopertina, HttpPostedFileBase Immagine1, HttpPostedFileBase Immagine2 )
        {
            if(ModelState.IsValid) { 
                if(ImmagineCopertina.ContentLength > 0) 
                {
                    string nomeFile = ImmagineCopertina.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/ImmaginiProgetto"), nomeFile);
                    ImmagineCopertina.SaveAs(path);
                    art.ImmagineCopertina = nomeFile;
                }
                else { art.ImmagineCopertina = ""; }
                if(Immagine1.ContentLength > 0)
                {
                    string nomeFile = Immagine1.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/ImmaginiProgetto"), nomeFile);
                    Immagine1.SaveAs(path);
                    art.Immagine1 = nomeFile;
                }
                else { art.Immagine1 = ""; }
                if(Immagine2.ContentLength > 0)
                {
                    string nomeFile = Immagine2.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/ImmaginiProgetto"), nomeFile);
                    Immagine2.SaveAs(path);
                    art.Immagine2 = nomeFile;
                }
                else { art.Immagine2 = ""; }
            try 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO ARTICOLI (NomeArticolo, PrezzoArticolo, DescrizioneArticolo, ImmagineCopertina, Immagine1, Immagine2)" +
                                    "VALUES (@NomeArticolo, @PrezzoArticolo, @DescrizioneArticolo, @ImmagineCopertina, @Immagine1, @Immagine2)";
                cmd.Parameters.AddWithValue("@NomeArticolo", art.NomeArticolo);
                cmd.Parameters.AddWithValue("@PrezzoArticolo", art.PrezzoArticolo);
                cmd.Parameters.AddWithValue("@DescrizioneArticolo", art.DescrizioneArticolo);
                cmd.Parameters.AddWithValue("@ImmagineCopertina", art.ImmagineCopertina);
                cmd.Parameters.AddWithValue("@Immagine1", art.Immagine1);
                cmd.Parameters.AddWithValue("@Immagine2", art.Immagine2);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {

            }
            finally { conn.Close(); }
                return RedirectToAction("Index");
            }
            else { return View(); }
            
        }
    }
}