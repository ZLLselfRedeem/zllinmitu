using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace DataTableStudy
{
    class Program
    {
        private void DemonstrateDtaView() 
        {
            DataTable table = new DataTable("table");
            DataColumn colItem = new DataColumn("item", Type.GetType("System.String"));
            table.Columns.Add(colItem);

            DataRow NewRow;
            for (int i = 0; i < 5; ++i) 
            {
                NewRow = table.NewRow();
                NewRow["item"] = "Item" + i;
                table.Rows.Add(NewRow);
            }

            table.Rows[0]["item"] = "cat";
            table.Rows[1][0] = "dog";
            // Commits all the changes made to this table since the last time AcceptChanges was called.
            // The DataRowState also changes: all Added and Modified rows become Unchanged, 
            // and Deleted rows are removed.
            table.AcceptChanges();

            DataView firstView = new DataView(table);
            DataView secondView = new DataView(table);
            PrintTableOrView(table, "Current Value in Table");

            firstView.RowStateFilter = DataViewRowState.ModifiedOriginal;
            PrintTableOrView(firstView, "First DataView: Modifiedoriginal");
            DataRowView rowView;
            rowView = secondView.AddNew();
            rowView["item"] = "fish";

            secondView.RowStateFilter = DataViewRowState.ModifiedCurrent
                | DataViewRowState.Added;
            PrintTableOrView(secondView, "Second DataVies: ModifiedCurent | Added");
        }

        private void PrintTableOrView(DataTable table, string label) 
        {
            Console.WriteLine("\n" + label);
            for (int i = 0; i < table.Rows.Count; ++i) 
            {
                Console.WriteLine("\table" + table.Rows[i]["item"]);
            }
            Console.WriteLine();
        }

        private void PrintTableOrView(DataView view, string label) 
        {
            Console.WriteLine("\n" + label);
            for (int i = 0; i < view.Count; i++) 
            {
                Console.WriteLine("\table" + view[i]["item"]);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Program pg = new Program();
            pg.DemonstrateDtaView();
            Console.ReadKey();
        }
    }
}
