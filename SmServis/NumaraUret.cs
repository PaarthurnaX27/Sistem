using System;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using Dapper;
using System.Drawing;

namespace SmServis
{
	public class NumaraUret
	{
        public  static  string dataBase = "";
        NumaratorManager nm = new NumaratorManager(new EfNumaratorDal());
        NumaratorDegerManager ndm = new NumaratorDegerManager(new EfNumaratorDegerDal());
        Numarator_TabloManager ntm = new Numarator_TabloManager(new EfNumarator_TabloDal());
        string connectionString = "User Id=postgres;Password=4909;Host=localhost;Port=5432;Database="+dataBase+";";
        public List<string> TableList()
        {



            List<string> tableList = new List<string>();
            string query = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public' AND table_name NOT IN (SELECT \"TabloAdi\" FROM \"Numarator_Tablos\") Order By table_name asc";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                       tableList.Add(row["TABLE_NAME"].ToString());
                    }
                }
            }
            return tableList;
        }
        public List<string> KolonList(string tabloAdi)
        {
            List<string> columns = new List<string>();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT column_name FROM information_schema.columns WHERE table_name = @tabloAdi";
                var columnNames = connection.Query<string>(query, new { tabloAdi }).ToList();
                foreach (string columnName in columnNames)
                {
                    columns.Add(columnName);
                }
            }
            return columns;
        }
        public string NumaraOlustur(int id,string tabloAdi)
        {
            var numaratorTablo=ntm.TGetList().Where(x => x.TabloAdi == tabloAdi).FirstOrDefault();
            int numaratorId = numaratorTablo.NumaratorId;
            var tblNumarator = nm.TGetByID(numaratorId);
            var tblNumaratorDeger = ndm.TGetList().Where(x => x.NumaratorId == numaratorId).FirstOrDefault();
            string no = "";
            string sira = "";
            int siraNo1 = Convert.ToInt32(tblNumarator.Sira1);
            int siraNo2 = Convert.ToInt32(tblNumarator.Sira2);
            int siraNo3 = Convert.ToInt32(tblNumarator.Sira3);
            int siraNo4 = Convert.ToInt32(tblNumarator.Sira4);
            int siraNo5 = Convert.ToInt32(tblNumarator.Sira5);
            int siraNo6 = Convert.ToInt32(tblNumarator.Sira6);
            int baslangic = 0;
            string sira1 = "";
            string sira2 = "";
            string sira3 = "";
            string sira4 = "";
            string sira5 = "";
            string sira6 = "";
            string kolonAdi1 = tblNumarator.Parametre1;
            string kolonAdi2 = tblNumarator.Parametre2;
            object kolonDeger1 = "";
            object kolonDeger2 = "";
            string idColumn= tabloAdi.Remove(tabloAdi.Length - 1);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT \"{kolonAdi1}\",\"{kolonAdi2}\" FROM \"{tabloAdi}\" WHERE \"{idColumn}Id\" = @id";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            kolonDeger1 = reader[kolonAdi1];
                            kolonDeger2 = reader[kolonAdi2];
                        }
                        else
                        {
                           
                        }
                    }
                }
            }


            if (siraNo1 != 0)
            {
                switch (siraNo1)
                {
                    case 1:
                        sira1 = DateTime.Now.Day.ToString();
                        break;
                    case 2:
                        sira1 = DateTime.Now.Month.ToString();
                        break;
                    case 3:
                        sira1 = DateTime.Now.Year.ToString();
                        break;
                    case 4:
                        sira1 = (tblNumaratorDeger.SimdikiDeger + tblNumarator.ArttirmaAraligi).ToString();
                        tblNumaratorDeger.SimdikiDeger = Convert.ToInt32(sira1);
                        ndm.TUpdate(tblNumaratorDeger);
                        break;
                    case 5:
                        sira1 = kolonDeger1.ToString();
                        break;
                    case 6:
                        sira1 = kolonDeger2.ToString();
                        break;
                    default:
                        break;
                }
            }
            if (siraNo2 != 0)
            {
                switch (siraNo2)
                {
                    case 1:
                        sira2 = DateTime.Now.Day.ToString();
                        break;
                    case 2:
                        sira2 = DateTime.Now.Month.ToString();
                        break;
                    case 3:
                        sira2 = DateTime.Now.Year.ToString();
                        break;
                    case 4:
                        if (baslangic != 0)
                        {
                            sira2 = baslangic.ToString();
                        }
                        else
                        {
                            sira2 = (tblNumaratorDeger.SimdikiDeger + tblNumarator.ArttirmaAraligi).ToString();

                        }
                        tblNumaratorDeger.SimdikiDeger = Convert.ToInt32(sira2);
                        ndm.TUpdate(tblNumaratorDeger);
                        break;
                    case 5:
                        sira2 = kolonDeger1.ToString();
                        break;
                    case 6:
                        sira2 = kolonDeger2.ToString();
                        break;
                    default:
                        break;
                }
            }
            if (siraNo3 != 0)
            {
                switch (siraNo3)
                {
                    case 1:
                        sira3 = DateTime.Now.Day.ToString();
                        break;
                    case 2:
                        sira3 = DateTime.Now.Month.ToString();
                        break;
                    case 3:
                        sira3 = DateTime.Now.Year.ToString();
                        break;
                    case 4:
                            sira3 = (tblNumaratorDeger.SimdikiDeger + tblNumarator.ArttirmaAraligi).ToString();
                        tblNumaratorDeger.SimdikiDeger = Convert.ToInt32(sira3);
                        ndm.TUpdate(tblNumaratorDeger);
                        break;
                    case 5:
                        sira3 = kolonDeger1.ToString();
                        break;
                    case 6:
                        sira3 = kolonDeger2.ToString();
                        break;
                    default:
                        break;
                }
            }
            if (siraNo4 != 0)
            {
                switch (siraNo4)
                {
                    case 1:
                        sira4 = DateTime.Now.Day.ToString();
                        break;
                    case 2:
                        sira4 = DateTime.Now.Month.ToString();
                        break;
                    case 3:
                        sira4 = DateTime.Now.Year.ToString();
                        break;
                    case 4:
                        sira4 = (tblNumaratorDeger.SimdikiDeger + tblNumarator.ArttirmaAraligi).ToString();
                        tblNumaratorDeger.SimdikiDeger = Convert.ToInt32(sira4);
                        ndm.TUpdate(tblNumaratorDeger);
                        break;
                    case 5:
                        sira4 = kolonDeger1.ToString();
                        break;
                    case 6:
                        sira4 = kolonDeger2.ToString();
                        break;
                    default:
                        break;
                }
            }
            if (siraNo5 != 0)
            {
                switch (siraNo5)
                {
                    case 1:
                        sira5 = DateTime.Now.Day.ToString();
                        break;
                    case 2:
                        sira5 = DateTime.Now.Month.ToString();
                        break;
                    case 3:
                        sira5 = DateTime.Now.Year.ToString();
                        break;
                    case 4:
                        sira5 = (tblNumaratorDeger.SimdikiDeger + tblNumarator.ArttirmaAraligi).ToString();
                        tblNumaratorDeger.SimdikiDeger = Convert.ToInt32(sira5);
                        ndm.TUpdate(tblNumaratorDeger);
                        break;
                    case 5:
                        sira5 = kolonDeger1.ToString();
                        break;
                    case 6:
                        sira5 = kolonDeger2.ToString();
                        break;
                    default:
                        break;
                }
            }
            if (siraNo6 != 0)
            {
                switch (siraNo6)
                {
                    case 1:
                        sira6 = DateTime.Now.Day.ToString();
                        break;
                    case 2:
                        sira6 = DateTime.Now.Month.ToString();
                        break;
                    case 3:
                        sira6 = DateTime.Now.Year.ToString();
                        break;
                    case 4:
                        sira6 = (tblNumaratorDeger.SimdikiDeger + tblNumarator.ArttirmaAraligi).ToString();
                        tblNumaratorDeger.SimdikiDeger = Convert.ToInt32(sira6);
                        ndm.TUpdate(tblNumaratorDeger);
                        break;
                    case 5:
                        sira6 = kolonDeger1.ToString();
                        break;
                    case 6:
                        sira6 = kolonDeger2.ToString();
                        break;
                    default:
                        break;
                }
            }


            no = tblNumarator.OnEk + sira1 + tblNumarator.Karakter1 + sira2 + tblNumarator.Karakter2 + sira3 + tblNumarator.Karakter3 + sira4 + tblNumarator.Karakter4 + sira5 + tblNumarator.Karakter5 + sira6 + tblNumarator.SonEk;
            tblNumarator.Numara += tblNumarator.ArttirmaAraligi;
            return no;
        }
    }
}

