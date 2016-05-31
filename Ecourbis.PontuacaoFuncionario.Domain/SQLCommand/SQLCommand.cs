using System;
using System.Collections.Generic;
using System.Text;

namespace Ecourbis.PontuacaoFuncionario.Domain.SQLCommand
{
    public class SQLCommand
    {
        private static StringBuilder sb;

        public static string getQryUb3Sintetico(bool isAtivo, string prdDe, string prdAte, string grupo)
        {
            string sinal = isAtivo ? "<>" : "=";
            sb = new StringBuilder();

            sb.Append("SELECT UA1.UA1_DESCRI as DESCRI, SUM(UB3_ADVMES) AS UB3_ADVMES, SUM(UB3_SUSMES) AS UB3_SUSMES, SUM(UB3_ATMES) AS UB3_ATMES, SUM(UB3_FALMES) AS UB3_FALMES, SUM(UB3_REEMES) AS UB3_REEMES,SUM(UB3_MULTAS) AS UB3_MULTAS,SUM(UB3_ACID) AS UB3_ACID,\n");
            sb.Append("SUM(UB3_ADVMES+UB3_SUSMES+UB3_ATMES+UB3_FALMES+UB3_REEMES) AS UB3_TOTAL\n");
            sb.Append("FROM UB3010 UB3 \n");
            sb.Append("	INNER JOIN SRA010 SRA ON UB3.UB3_MAT = SRA.RA_MAT AND SRA.D_E_L_E_T_ = ''\n");
            sb.Append("	INNER JOIN CTT010 CTT ON SRA.RA_CC = CTT.CTT_CUSTO AND CTT.D_E_L_E_T_ = ''\n");
            sb.Append("	INNER JOIN UA1010 UA1 ON SRA.RA_CC = UA1.UA1_CCUSTO AND UA1.D_E_L_E_T_ = ''\n");
            sb.Append("WHERE UB3.D_E_L_E_T_ = ''\n");

            sb.Append("	AND UB3_SITFOL " + sinal + " 'D'\n");

            sb.Append("AND UB3_DTARQ BETWEEN '" + prdDe + "' AND '" + prdAte + "'\n");
            sb.Append("AND UA1.UA1_GRUPO = '" + grupo + "'\n");
            sb.Append("GROUP BY UA1.UA1_GRUPO, UA1.UA1_DESCRI\n");
            sb.Append("ORDER BY UA1.UA1_GRUPO, UA1.UA1_DESCRI, UB3_TOTAL\n");

            return sb.ToString();
        }

        public static string getQryUb3Analitico(bool isAtivo, string prdDe, string prdAte, string grupo)
        {
            string sinal = isAtivo ? "<>" : "=";
            sb = new StringBuilder();
            sb.Append("SELECT UA1.UA1_DESCRI AS UNIDADE, SRA.RA_CC AS CC, CTT.CTT_DESC01 AS DESC_CC, UB3_MAT  + ' - '+ SRA.RA_NOME AS UB3_MAT,\n");
            if (isAtivo)
                sb.Append("UB3_DEMIS,\n");
            else
                sb.Append("CONVERT(VARCHAR,CAST(UB3_DEMIS AS datetime),103) as UB3_DEMIS,\n");

            sb.Append("CONVERT(VARCHAR,CAST(UB3_DEMIS AS datetime),103) as UB3_DEMIS,\n");
            sb.Append("SUM(UB3_ADVMES) AS UB3_ADVMES, SUM(UB3_SUSMES) AS UB3_SUSMES, SUM(UB3_ATMES) AS UB3_ATMES, SUM(UB3_FALMES) AS UB3_FALMES, SUM(UB3_REEMES) AS UB3_REEMES,SUM(UB3_MULTAS) AS UB3_MULTAS,SUM(UB3_ACID) AS UB3_ACID,\n");
            sb.Append("SUM(UB3_ADVMES+UB3_SUSMES+UB3_ATMES+UB3_FALMES+UB3_REEMES) AS UB3_TOTAL\n");
            sb.Append("FROM UB3010 UB3\n");
            sb.Append("	INNER JOIN SRA010 SRA ON UB3.UB3_MAT = SRA.RA_MAT AND SRA.D_E_L_E_T_ = ''\n");
            sb.Append("	INNER JOIN CTT010 CTT ON SRA.RA_CC = CTT.CTT_CUSTO AND CTT.D_E_L_E_T_ = ''\n");
            sb.Append("	INNER JOIN UA1010 UA1 ON SRA.RA_CC = UA1.UA1_CCUSTO AND UA1.UA1_GRUPO = '" + grupo + "' AND UA1.D_E_L_E_T_ = '' \n");
            sb.Append("WHERE UB3.D_E_L_E_T_ = ''\n");

            sb.Append("	AND UB3_SITFOL " + sinal + " 'D'\n");

            sb.Append("AND UB3_DTARQ BETWEEN '" + prdDe + "' AND '" + prdAte + "'\n");
            sb.Append("GROUP BY UA1.UA1_DESCRI, SRA.RA_CC, CTT.CTT_DESC01, UB3.UB3_MAT, SRA.RA_NOME,UB3_DEMIS\n");
            sb.Append("HAVING SUM(UB3_ADVMES+UB3_SUSMES+UB3_ATMES+UB3_FALMES+UB3_REEMES) > 0");

            return sb.ToString();
        }

        public static string getQryFechamentoPonto()
        {
            return "SELECT convert(varchar,cast(MAX(PO_DATAFIM) AS datetime),103) AS DATA FROM SPO010";
        }

        public static string getQryPrdClose(string grupo, bool isAtivo, List<string> anomes)
        {
            string sinal = isAtivo ? "<>" : "=";
            sb = new StringBuilder();
            sb.Append("SELECT UA1_GRUPO, UA1_DESCRI,\n");
            sb.Append("     SUM(QD1." + getM(anomes[0]) + ") AS " + getM(anomes[0]) + ",SUM(QD1." + getM(anomes[1]) + ") AS " + getM(anomes[1]) + ",\n");
            sb.Append("     SUM(QD1." + getM(anomes[2]) + ") AS " + getM(anomes[2]) + ",SUM(QD1." + getM(anomes[3]) + ") AS " + getM(anomes[3]) + ",\n");
            sb.Append("     SUM(QD1." + getM(anomes[4]) + ") AS " + getM(anomes[4]) + ",SUM(QD1." + getM(anomes[5]) + ") AS " + getM(anomes[5]) + ",\n");
            sb.Append("     SUM(QD1." + getM(anomes[6]) + ") AS " + getM(anomes[6]) + ",SUM(QD1." + getM(anomes[7]) + ") AS " + getM(anomes[7]) + ",\n");
            sb.Append("     SUM(QD1." + getM(anomes[8]) + ") AS " + getM(anomes[8]) + ",SUM(QD1." + getM(anomes[9]) + ") AS " + getM(anomes[9]) + ",\n");
            sb.Append("     SUM(QD1." + getM(anomes[10]) + ") AS " + getM(anomes[10]) + ",SUM(QD1." + getM(anomes[11]) + ") AS " + getM(anomes[11]) + ", \n");
            sb.Append("     SUM(" + getSumPrd(anomes) + ") AS TOTAL\n");
            sb.Append("FROM \n");
            sb.Append("(\n");
            sb.Append("	SELECT UA1.UA1_GRUPO, UA1.UA1_DESCRI, \n");
            sb.Append("		   /* retroagir dinamicamente para os meses anteriores*/\n");
            sb.Append("		   CASE UB3.UB3_DTARQ WHEN '" + anomes[0] + "' THEN SUM(UB3_ADVMES+UB3_SUSMES+UB3_ATMES+UB3_FALMES+UB3_REEMES+UB3_MULTAS+UB3_ACID) ELSE 0 END AS " + getM(anomes[0]) + ",\n");
            sb.Append("		   CASE UB3.UB3_DTARQ WHEN '" + anomes[1] + "' THEN SUM(UB3_ADVMES+UB3_SUSMES+UB3_ATMES+UB3_FALMES+UB3_REEMES+UB3_MULTAS+UB3_ACID) ELSE 0 END AS " + getM(anomes[1]) + ",\n");
            sb.Append("		   CASE UB3.UB3_DTARQ WHEN '" + anomes[2] + "' THEN SUM(UB3_ADVMES+UB3_SUSMES+UB3_ATMES+UB3_FALMES+UB3_REEMES+UB3_MULTAS+UB3_ACID) ELSE 0 END AS " + getM(anomes[2]) + ",\n");
            sb.Append("		   CASE UB3.UB3_DTARQ WHEN '" + anomes[3] + "' THEN SUM(UB3_ADVMES+UB3_SUSMES+UB3_ATMES+UB3_FALMES+UB3_REEMES+UB3_MULTAS+UB3_ACID) ELSE 0 END AS " + getM(anomes[3]) + ",\n");
            sb.Append("		   CASE UB3.UB3_DTARQ WHEN '" + anomes[4] + "' THEN SUM(UB3_ADVMES+UB3_SUSMES+UB3_ATMES+UB3_FALMES+UB3_REEMES+UB3_MULTAS+UB3_ACID) ELSE 0 END AS " + getM(anomes[4]) + ",\n");
            sb.Append("		   CASE UB3.UB3_DTARQ WHEN '" + anomes[5] + "' THEN SUM(UB3_ADVMES+UB3_SUSMES+UB3_ATMES+UB3_FALMES+UB3_REEMES+UB3_MULTAS+UB3_ACID) ELSE 0 END AS " + getM(anomes[5]) + ",\n");
            sb.Append("		   CASE UB3.UB3_DTARQ WHEN '" + anomes[6] + "' THEN SUM(UB3_ADVMES+UB3_SUSMES+UB3_ATMES+UB3_FALMES+UB3_REEMES+UB3_MULTAS+UB3_ACID) ELSE 0 END AS " + getM(anomes[6]) + ",\n");
            sb.Append("		   CASE UB3.UB3_DTARQ WHEN '" + anomes[7] + "' THEN SUM(UB3_ADVMES+UB3_SUSMES+UB3_ATMES+UB3_FALMES+UB3_REEMES+UB3_MULTAS+UB3_ACID) ELSE 0 END AS " + getM(anomes[7]) + ",\n");
            sb.Append("		   CASE UB3.UB3_DTARQ WHEN '" + anomes[8] + "' THEN SUM(UB3_ADVMES+UB3_SUSMES+UB3_ATMES+UB3_FALMES+UB3_REEMES+UB3_MULTAS+UB3_ACID) ELSE 0 END AS " + getM(anomes[8]) + ",\n");
            sb.Append("		   CASE UB3.UB3_DTARQ WHEN '" + anomes[9] + "' THEN SUM(UB3_ADVMES+UB3_SUSMES+UB3_ATMES+UB3_FALMES+UB3_REEMES+UB3_MULTAS+UB3_ACID) ELSE 0 END AS " + getM(anomes[9]) + ",\n");
            sb.Append("		   CASE UB3.UB3_DTARQ WHEN '" + anomes[10] + "' THEN SUM(UB3_ADVMES+UB3_SUSMES+UB3_ATMES+UB3_FALMES+UB3_REEMES+UB3_MULTAS+UB3_ACID) ELSE 0 END AS " + getM(anomes[10]) + ",\n");
            sb.Append("		   CASE UB3.UB3_DTARQ WHEN '" + anomes[11] + "' THEN SUM(UB3_ADVMES+UB3_SUSMES+UB3_ATMES+UB3_FALMES+UB3_REEMES+UB3_MULTAS+UB3_ACID) ELSE 0 END AS " + getM(anomes[11]) + "\n");
            sb.Append("	FROM UB3010 UB3 INNER JOIN SRA010 SRA ON UB3.UB3_MAT = SRA.RA_MAT AND SRA.D_E_L_E_T_ = ''\n");
            sb.Append("	INNER JOIN CTT010 CTT ON SRA.RA_CC = CTT.CTT_CUSTO AND CTT.D_E_L_E_T_ = ''\n");
            sb.Append("	INNER JOIN UA1010 UA1 ON SRA.RA_CC = UA1.UA1_CCUSTO AND UA1.D_E_L_E_T_ = ''\n");
            sb.Append("	WHERE UB3.D_E_L_E_T_ = ''\n");

            sb.Append("	AND UB3_SITFOL " + sinal + " 'D'\n");

            if (!"".Equals(grupo))
                sb.Append(" AND UA1_GRUPO IN (" + grupo + ")\n");

            sb.Append("	AND UB3_DTARQ BETWEEN '" + anomes[0] + "' AND '" + anomes[11] + "'\n");
            sb.Append("	GROUP BY UA1.UA1_GRUPO, UA1.UA1_DESCRI, UB3.UB3_DTARQ\n");
            sb.Append(") AS QD1\n");
            sb.Append("GROUP BY UA1_GRUPO, UA1_DESCRI \n");
            sb.Append("ORDER BY UA1_GRUPO, UA1_DESCRI\n");
            return sb.ToString();
        }

        public static string getDadosFunce(string matricula)
        {
            sb = new StringBuilder();
            sb.Append("SELECT\n");
            sb.Append("     RA_MAT AS MAT,\n");
            sb.Append("     RA_NOME AS NOME,\n");
            sb.Append("     RA_CC AS CC,\n");
            sb.Append("     CONVERT(varchar, CAST(RA_ADMISSA AS datetime), 103) AS ADMISSAO,\n");
            sb.Append("     CASE\n");
            sb.Append("         WHEN RA_DEMISSA = '' THEN '' ELSE CONVERT(varchar, CAST(RA_DEMISSA AS datetime), 103)\n");
            sb.Append("     END AS DEMISSAO,\n");
            sb.Append("     dbo.fnc_JustDemiss('" + matricula + "') AS JUSTDEMISSAO\n");
            sb.Append("FROM SRA010\n");
            sb.Append("WHERE RA_MAT = '" + matricula + "'\n");
            sb.Append("AND D_E_L_E_T_ = ' '\n");

            return sb.ToString();
        }

        public static string getDetalhesFunce(string matricula)
        {
            sb = new StringBuilder();
            sb.Append("SELECT\n");
            sb.Append("    SUBSTRING(UB3_DTARQ, 5, 2) + '/' + SUBSTRING(UB3_DTARQ, 1, 4) AS MESANO,\n");
            sb.Append("    UB3_ADVMES,\n");
            sb.Append("    UB3_SUSMES,\n");
            sb.Append("    UB3_ATMES,\n");
            sb.Append("    UB3_FALMES,\n");
            sb.Append("    UB3_REEMES,\n");
            sb.Append("    UB3_MULTAS,\n");
            sb.Append("    UB3_ACID,\n");
            sb.Append("    (UB3_ADVMES + UB3_SUSMES + UB3_ATMES + UB3_FALMES + UB3_REEMES + UB3_MULTAS + UB3_ACID) AS UB3_TOTAL\n");
            sb.Append("FROM UB3010\n");
            sb.Append("WHERE UB3_FILIAL = '  '\n");
            sb.Append("AND UB3_MAT = '" + matricula + "'\n");
            sb.Append("AND D_E_L_E_T_ = ' '\n");

            return sb.ToString();
        }

        /// <summary>
        /// retorna o mes correspondente de forma literal
        /// </summary>
        /// <param name="anomes"></param>
        /// <returns></returns>
        public static string getM(string anomes)
        {
            string mes = string.Empty;
            switch (anomes.Substring(4, 2))
            {
                case "01": mes = "[JAN]"; break;
                case "02": mes = "[FEV]"; break;
                case "03": mes = "[MAR]"; break;
                case "04": mes = "[ABR]"; break;
                case "05": mes = "[MAI]"; break;
                case "06": mes = "[JUN]"; break;
                case "07": mes = "[JUL]"; break;
                case "08": mes = "[AGO]"; break;
                case "09": mes = "[SET]"; break;
                case "10": mes = "[OUT]"; break;
                case "11": mes = "[NOV]"; break;
                default: mes = "[DEZ]"; break;
            }

            return mes;
        }

        /// <summary>
        /// retorna a concatenação dos meses para a somatoria do total na query
        /// </summary>
        /// <param name="anomes"></param>
        /// <returns></returns>
        private static string getSumPrd(List<string> anomes)
        {
            return "QD1." + getM(anomes[0]) + " + QD1." + getM(anomes[1]) + " + QD1." + getM(anomes[2])
                    + " + QD1." + getM(anomes[3]) + "+ QD1." + getM(anomes[4]) + " + QD1." + getM(anomes[5])
                    + " + QD1." + getM(anomes[6]) + " + QD1." + getM(anomes[7]) + " + QD1." + getM(anomes[8])
                    + " + QD1." + getM(anomes[9]) + " + QD1." + getM(anomes[10]) + " + QD1." + getM(anomes[11]) + "";
        }
    }
}
