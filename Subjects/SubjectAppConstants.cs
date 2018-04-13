using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subjects
{
    public static class SubjectAppConstants
    {
        // Message captions
        public const string CaptionWrnDeleteItem = "Confirm Delete";
        public const string CaptionErrDeleteItem = "Delete Failed";
        public const string CaptionErrExport = "Export Failed";
        public const string CaptionInfoHelp = "Help";
        public const string CaptionErrData = "Data Invalid";
        public const string CaptionInfoRecordAdded = "Insert Successfull";
        public const string CaptionErrInsert = "Insert Failed";
        public const string CaptionErrUpdate = "Update Failed";

        // Message texts
        public const string ErrDBLoad = "Database Load Failed";
        public const string WrnDeleteItem = "Are you sure you want to delete selected item(s)?";
        public const string InfoRecordAdded = "Record successfully added.";

        // Validation message texts
        public const string MsgValidationIco = "Enter valid Ico number.";
        public const string MsgValidationNazev = "Maximal Nazev length is 60 characters.";
        public const string MsgValidationUlice = "Maximal Ulice length is 60 characters.";
        public const string MsgValidationObec = "Maximal Obec length is 60 characters.";
        public const string MsgValidationPsc = "Enter valid Psc number.";
        public const string MsgValidationPscLen = "Maximal Psc length is 5 characters.";
    }
}
