using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hastane
{
    class SumMoney
    {
        public static decimal sumMoney(DataGridView dataGridView) {
            decimal toplamMiktar = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Miktar"].Value != null && row.Cells["birim_fiyat"].Value != null)
                {

                    decimal miktar = Convert.ToDecimal(row.Cells["Miktar"].Value);
                    decimal birimf = Convert.ToDecimal(row.Cells["birim_fiyat"].Value);
                    toplamMiktar += birimf * miktar;
                }
            }
            return toplamMiktar;
        }
    }
}
