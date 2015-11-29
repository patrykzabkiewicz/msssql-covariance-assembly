using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


[Serializable]
[SqlUserDefinedAggregate(Format.Native, Name = "Cov")]
public struct COV
{
    private double sumaX;
    private double sumaY;
    private double sumaXY;
    private double ilosc;

    public void Init()
    {
        sumaX = 0;
        sumaY = 0;
        sumaXY = 0;
        ilosc = 0;
    }

    public void Accumulate(double x, double y)
    {
            sumaX += x;
            sumaY += y;
            sumaXY += x * y;
            ilosc++;
    }

    public void Merge(COV group)
    {
        this.sumaX += group.sumaX;
        this.sumaY += group.sumaY;
        this.sumaXY += group.sumaXY;
        this.ilosc += group.ilosc;
    }

    public SqlDouble Terminate()
    {
        return new SqlDouble((sumaXY - (sumaX * sumaY) / ilosc) / ilosc);
    }
}
