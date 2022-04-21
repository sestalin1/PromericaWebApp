using PromericaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PromericaWebApp.DataAccess
{
    public class DataAccessLayer
    {

        public string InsertData(TipoPrestamo tPrestamo)

        {



            SqlConnection con = null;

            string result = "";

            try

            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["promericaCon"].ToString());

                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Tipo_Prestamo", con);

                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@TipoPrestamo", tPrestamo.tipoPrestamo);

                cmd.Parameters.AddWithValue("@tasa", tPrestamo.tasa);

                cmd.Parameters.AddWithValue("@Query", 1);

                con.Open();

                result = cmd.ExecuteScalar().ToString();

                return result;

            }

            catch

            {

                return result = "";

            }

            finally

            {

                con.Close();

            }

        }



        public string UpdateData(TipoPrestamo tPrestamo)

        {

            SqlConnection con = null;

            string result = "";

            try

            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["promericaCon"].ToString());

                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Tipo_Prestamo", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TipoPrestamo", tPrestamo.tipoPrestamo);

                cmd.Parameters.AddWithValue("@tasa", tPrestamo.tasa);

                cmd.Parameters.AddWithValue("@Query", 2);

                con.Open();

                result = cmd.ExecuteScalar().ToString();

                return result;

            }

            catch

            {

                return result = "";

            }

            finally

            {

                con.Close();

            }

        }

        public string DeleteData(TipoPrestamo tPrestamo)

        {

            SqlConnection con = null;

            string result = "";

            try

            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["promericaCon"].ToString());

                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Tipo_Prestamo", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TipoPrestamo", tPrestamo.tipoPrestamo);

                cmd.Parameters.AddWithValue("@tasa", null);

                cmd.Parameters.AddWithValue("@Query", 3);

                con.Open();

                result = cmd.ExecuteScalar().ToString();

                return result;

            }

            catch

            {

                return result = "";

            }

            finally

            {

                con.Close();

            }

        }

        public List<TipoPrestamo> Selectalldata()

        {

            SqlConnection con = null;



            DataSet ds = null;

            List<TipoPrestamo> tPrestamoList = null;

            try

            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["promericaCon"].ToString());

                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Tipo_Prestamo", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TipoPrestamo", null);

                cmd.Parameters.AddWithValue("@tasa", null);

                cmd.Parameters.AddWithValue("@Query", 4);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;

                ds = new DataSet();

                da.Fill(ds);

                tPrestamoList = new List<TipoPrestamo>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)

                {

                    TipoPrestamo TPObj = new TipoPrestamo();

                    TPObj.tipoPrestamo = ds.Tables[0].Rows[i]["tipo_prestamo"].ToString();

                    TPObj.tasa = Convert.ToDouble(ds.Tables[0].Rows[i]["tasa"].ToString());

                    tPrestamoList.Add(TPObj);

                }

                return tPrestamoList;

            }

            catch

            {

                return tPrestamoList;

            }

            finally

            {

                con.Close();

            }

        }


        public TipoPrestamo SelectDatabyID(string tipoPrestamoID)

        {

            SqlConnection con = null;

            DataSet ds = null;

            TipoPrestamo TPObj = null;

            try

            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["promericaCon"].ToString());

                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Tipo_Prestamo", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamoID);

                cmd.Parameters.AddWithValue("@tasa", null);

                cmd.Parameters.AddWithValue("@Query", 5);

                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;

                ds = new DataSet();

                da.Fill(ds);



                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)

                {

                    TPObj = new TipoPrestamo();

                    TPObj.tipoPrestamo = ds.Tables[0].Rows[i]["tipo_prestamo"].ToString();

                    TPObj.tasa = Convert.ToDouble(ds.Tables[0].Rows[i]["tasa"].ToString());

                }

                return TPObj;

            }

            catch

            {

                return TPObj;

            }

            finally

            {

                con.Close();

            }

        }


        public List<Prestamo> SelectalldataP()

        {

            SqlConnection con = null;



            DataSet ds = null;

            List<Prestamo> PrestamoList = null;

            try

            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["promericaCon"].ToString());

                SqlCommand cmd = new SqlCommand("Usp_Read_Prestamo", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;

                ds = new DataSet();

                da.Fill(ds);

                PrestamoList = new List<Prestamo>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)

                {

                    Prestamo PObj = new Prestamo();

                    PObj.numeroPrestamo = Convert.ToInt32(ds.Tables[0].Rows[i]["No_Prestamo"].ToString());
                    PObj.fechaApertura = Convert.ToDateTime(ds.Tables[0].Rows[i]["Fecha_Apertura"].ToString());
                    PObj.numeroCliente = Convert.ToInt32(ds.Tables[0].Rows[i]["No_Cliente"].ToString());
                    PObj.cedula = ds.Tables[0].Rows[i]["Cedula"].ToString();
                    PObj.nombreAgencia = ds.Tables[0].Rows[i]["Nombre_Agencia"].ToString();

                    PObj.monto = Convert.ToDouble(ds.Tables[0].Rows[i]["Monto"].ToString());
                    PObj.tasa = Convert.ToDouble(ds.Tables[0].Rows[i]["Tasa"].ToString());
                    PObj.valor = Convert.ToDouble(ds.Tables[0].Rows[i]["Valor"].ToString());

                    PrestamoList.Add(PObj);

                }

                return PrestamoList;

            }

            catch

            {

                return PrestamoList;

            }

            finally

            {

                con.Close();

            }

        }


    }
}