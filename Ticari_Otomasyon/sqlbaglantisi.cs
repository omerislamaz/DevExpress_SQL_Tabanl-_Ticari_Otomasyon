﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-R2R0K4B;Initial Catalog=DboTicariOtomasyon;Integrated Security=True;Encrypt=False");
            baglan.Open();
            return baglan;
        }
    }
}
