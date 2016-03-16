using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFAxeCreditFull_
{
     public class Foreignkey
    {
     public string    FK_Table {get;set;}
     public string   FK_Column {get;set;}
     public string     PK_Table{get;set;}
     public string    PK_Column {get;set;}
     public string Constraint_Name { get; set; }

    }
}
