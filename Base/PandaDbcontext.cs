using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Context
{
    public class PandaDbcontext:DbContext
    {
        public PandaDbcontext() : base("PandaEntities") {
            Database.CreateIfNotExists();
        }
        public virtual DbSet<ACCOUNT> ACCOUNTS { get; set; }
        public virtual DbSet<BARCODE> BARCODE { get; set; }
        public virtual DbSet<CARD_NO> CARD_NO { get; set; }
        public virtual DbSet<CARD_TYPE> CARD_TYPE { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENT { get; set; }
        public virtual DbSet<DETAIL_SALE> DETAIL_SALE { get; set; }
        public virtual DbSet<DEVICE> DEVICE { get; set; }
        public virtual DbSet<DEVICE_TYPE> DEVICE_TYPE { get; set; }
        public virtual DbSet<DISCOUNT> DISCOUNT { get; set; }
        public virtual DbSet<DISCOUNT_TYPE> DISCOUNT_TYPE { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEES { get; set; }
        public virtual DbSet<GAME_SPORT> GAME_SPORT { get; set; }
        public virtual DbSet<HOLIDAY> HOLIDAY { get; set; }
        public virtual DbSet<IO_INFO> IO_INFO { get; set; }
        public virtual DbSet<MENULIST> MENULIST { get; set; }
        public virtual DbSet<PRIVILE> PRIVILES { get; set; }
        public virtual DbSet<REDEEM> REDEEM { get; set; }
        public virtual DbSet<REDEEM_TRANSFORM> REDEEM_TRANSFORM { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TICKET_PRICE> TICKET_PRICE { get; set; }
        public virtual DbSet<TICKET_SALE> TICKET_SALE { get; set; }
        public virtual DbSet<TICKET_TYPE> TICKET_TYPE { get; set; }
        public virtual DbSet<TIME_FRAME> TIME_FRAME { get; set; }
        public virtual DbSet<UNIT> UNIT { get; set; }
        public virtual DbSet<USER_INFO> USER_INFO { get; set; }
        public virtual DbSet<USER_TYPE> USER_TYPE { get; set; }
        public virtual DbSet<VISIBLECONTROLS> VISIBLECONTROLS { get; set; }
        public virtual DbSet<ZONE> ZONE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ACCOUNTS>().ToTable("ACCOUNTS").HasKey(c => c.ACC_ID);
            modelBuilder.Entity<BARCODE>().ToTable("BARCODE").HasKey(c=>c.BAR_ID);
            modelBuilder.Entity<CARD_NO>().ToTable("CARD_NO").HasKey(c => c.CA_ID);
            modelBuilder.Entity<CARD_TYPE>().ToTable("CARD_TYPE").HasKey(c => c.CT_ID);
            modelBuilder.Entity<DEPARTMENT>().ToTable("DEPARTMENT").HasKey(c => c.DEP_ID);
            modelBuilder.Entity<DETAIL_SALE>().ToTable("DETAIL_SALE").HasKey(c => c.DTS_ID);
            modelBuilder.Entity<DEVICE>().ToTable("DEVICE").HasKey(c => c.DEVICE_ID);
            modelBuilder.Entity<DEVICE_TYPE>().ToTable("DEVICE_TYPE").HasKey(c => c.DT_ID);
            modelBuilder.Entity<DISCOUNT_TYPE>().ToTable("DISCOUNT_TYPE").HasKey(c => c.DISCT_ID);
            modelBuilder.Entity<DISCOUNT>().ToTable("DISCOUNT").HasKey(c => c.DISC_ID);
            modelBuilder.Entity<EMPLOYEES>().ToTable("EMPLOYEES").HasKey(c => c.EM_ID);
            modelBuilder.Entity<GAME_SPORT>().ToTable("GAME_SPORT").HasKey(c => c.GS_ID);
            modelBuilder.Entity<HOLIDAY>().ToTable("HOLIDAY").HasKey(c => c.HOL_ID);
            modelBuilder.Entity<IO_INFO>().ToTable("IO_INFO").HasKey(c => c.IO_ID);
            modelBuilder.Entity<PRIVILES>().ToTable("PRIVILES").HasKey(c => c.PRI_ID);
            modelBuilder.Entity<REDEEM>().ToTable("REDEEM").HasKey(c => c.REDEEM_ID);
            modelBuilder.Entity<REDEEM_TRANSFORM>().ToTable("REDEEM_TRANSFORM").HasKey(c => c.ID);
            modelBuilder.Entity<TICKET_PRICE>().ToTable("TICKET_PRICE").HasKey(c => c.PRICE_ID);
            modelBuilder.Entity<TICKET_SALE>().ToTable("TICKET_SALE").HasKey(c => c.TS_ID);
            modelBuilder.Entity<TICKET_TYPE>().ToTable("TICKET_TYPE").HasKey(c => c.TYPEID);
            modelBuilder.Entity<TIME_FRAME>().ToTable("TIME_FRAME").HasKey(c => c.TF_ID);
            modelBuilder.Entity<UNIT>().ToTable("UNIT").HasKey(c => c.UNIT_ID);
            modelBuilder.Entity<USER_INFO>().ToTable("USER_INFO").HasKey(c => c.USER_ID);
            modelBuilder.Entity<USER_TYPE>().ToTable("USER_TYPE").HasKey(c => c.USER_TYPEID);
            modelBuilder.Entity<VISIBLECONTROLS>().ToTable("VISIBLECONTROLS").HasKey(c => c.VI_ID);
            modelBuilder.Entity<ZONE>().ToTable("ZONE").HasKey(c => c.ZONE_ID);

           
        }

        //public virtual int accounts_ChangePassword(Nullable<int> aCC_ID, string aCC_PASSWORD, string newPassword)
        //{
        //    var aCC_IDParameter = aCC_ID.HasValue ?
        //        new ObjectParameter("ACC_ID", aCC_ID) :
        //        new ObjectParameter("ACC_ID", typeof(int));

        //    var aCC_PASSWORDParameter = aCC_PASSWORD != null ?
        //        new ObjectParameter("ACC_PASSWORD", aCC_PASSWORD) :
        //        new ObjectParameter("ACC_PASSWORD", typeof(string));

        //    var newPasswordParameter = newPassword != null ?
        //        new ObjectParameter("newPassword", newPassword) :
        //        new ObjectParameter("newPassword", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("accounts_ChangePassword", aCC_IDParameter, aCC_PASSWORDParameter, newPasswordParameter);
        //}

        //public virtual ObjectResult<accounts_CheckLogin_Result> accounts_CheckLogin(string userName, string password)
        //{
        //    var userNameParameter = userName != null ?
        //        new ObjectParameter("userName", userName) :
        //        new ObjectParameter("userName", typeof(string));

        //    var passwordParameter = password != null ?
        //        new ObjectParameter("password", password) :
        //        new ObjectParameter("password", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<accounts_CheckLogin_Result>("accounts_CheckLogin", userNameParameter, passwordParameter);
        //}

        //public virtual int accounts_Delete(Nullable<int> aCC_ID)
        //{
        //    var aCC_IDParameter = aCC_ID.HasValue ?
        //        new ObjectParameter("ACC_ID", aCC_ID) :
        //        new ObjectParameter("ACC_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("accounts_Delete", aCC_IDParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> accounts_GetACC_IDfromEM_ID(Nullable<int> eM_ID)
        //{
        //    var eM_IDParameter = eM_ID.HasValue ?
        //        new ObjectParameter("EM_ID", eM_ID) :
        //        new ObjectParameter("EM_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("accounts_GetACC_IDfromEM_ID", eM_IDParameter);
        //}

        //public virtual ObjectResult<accounts_GetAll_Result> accounts_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<accounts_GetAll_Result>("accounts_GetAll");
        //}

        //public virtual int accounts_insert(Nullable<int> aCC_ID, Nullable<int> pRI_ID, Nullable<int> eM_ID, string aCC_USERNAME, string aCC_PASSWORD, Nullable<bool> aCC_STATUS)
        //{
        //    var aCC_IDParameter = aCC_ID.HasValue ?
        //        new ObjectParameter("ACC_ID", aCC_ID) :
        //        new ObjectParameter("ACC_ID", typeof(int));

        //    var pRI_IDParameter = pRI_ID.HasValue ?
        //        new ObjectParameter("PRI_ID", pRI_ID) :
        //        new ObjectParameter("PRI_ID", typeof(int));

        //    var eM_IDParameter = eM_ID.HasValue ?
        //        new ObjectParameter("EM_ID", eM_ID) :
        //        new ObjectParameter("EM_ID", typeof(int));

        //    var aCC_USERNAMEParameter = aCC_USERNAME != null ?
        //        new ObjectParameter("ACC_USERNAME", aCC_USERNAME) :
        //        new ObjectParameter("ACC_USERNAME", typeof(string));

        //    var aCC_PASSWORDParameter = aCC_PASSWORD != null ?
        //        new ObjectParameter("ACC_PASSWORD", aCC_PASSWORD) :
        //        new ObjectParameter("ACC_PASSWORD", typeof(string));

        //    var aCC_STATUSParameter = aCC_STATUS.HasValue ?
        //        new ObjectParameter("ACC_STATUS", aCC_STATUS) :
        //        new ObjectParameter("ACC_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("accounts_insert", aCC_IDParameter, pRI_IDParameter, eM_IDParameter, aCC_USERNAMEParameter, aCC_PASSWORDParameter, aCC_STATUSParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> accounts_IsExistsAccount(Nullable<int> em_ID)
        //{
        //    var em_IDParameter = em_ID.HasValue ?
        //        new ObjectParameter("em_ID", em_ID) :
        //        new ObjectParameter("em_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("accounts_IsExistsAccount", em_IDParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> accounts_IsExistsUserName(string userName)
        //{
        //    var userNameParameter = userName != null ?
        //        new ObjectParameter("userName", userName) :
        //        new ObjectParameter("userName", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("accounts_IsExistsUserName", userNameParameter);
        //}

        //public virtual int accounts_ResetPass(Nullable<int> aCC_ID, string newPassword)
        //{
        //    var aCC_IDParameter = aCC_ID.HasValue ?
        //        new ObjectParameter("ACC_ID", aCC_ID) :
        //        new ObjectParameter("ACC_ID", typeof(int));

        //    var newPasswordParameter = newPassword != null ?
        //        new ObjectParameter("newPassword", newPassword) :
        //        new ObjectParameter("newPassword", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("accounts_ResetPass", aCC_IDParameter, newPasswordParameter);
        //}

        //public virtual int accounts_update(Nullable<int> aCC_ID, Nullable<int> pRI_ID, Nullable<int> eM_ID, string aCC_USERNAME, string aCC_PASSWORD, Nullable<bool> aCC_STATUS)
        //{
        //    var aCC_IDParameter = aCC_ID.HasValue ?
        //        new ObjectParameter("ACC_ID", aCC_ID) :
        //        new ObjectParameter("ACC_ID", typeof(int));

        //    var pRI_IDParameter = pRI_ID.HasValue ?
        //        new ObjectParameter("PRI_ID", pRI_ID) :
        //        new ObjectParameter("PRI_ID", typeof(int));

        //    var eM_IDParameter = eM_ID.HasValue ?
        //        new ObjectParameter("EM_ID", eM_ID) :
        //        new ObjectParameter("EM_ID", typeof(int));

        //    var aCC_USERNAMEParameter = aCC_USERNAME != null ?
        //        new ObjectParameter("ACC_USERNAME", aCC_USERNAME) :
        //        new ObjectParameter("ACC_USERNAME", typeof(string));

        //    var aCC_PASSWORDParameter = aCC_PASSWORD != null ?
        //        new ObjectParameter("ACC_PASSWORD", aCC_PASSWORD) :
        //        new ObjectParameter("ACC_PASSWORD", typeof(string));

        //    var aCC_STATUSParameter = aCC_STATUS.HasValue ?
        //        new ObjectParameter("ACC_STATUS", aCC_STATUS) :
        //        new ObjectParameter("ACC_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("accounts_update", aCC_IDParameter, pRI_IDParameter, eM_IDParameter, aCC_USERNAMEParameter, aCC_PASSWORDParameter, aCC_STATUSParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> barcode_check_reset_number(Nullable<System.DateTime> gENDATE)
        //{
        //    var gENDATEParameter = gENDATE.HasValue ?
        //        new ObjectParameter("GENDATE", gENDATE) :
        //        new ObjectParameter("GENDATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("barcode_check_reset_number", gENDATEParameter);
        //}

        //public virtual int barcode_delete(Nullable<long> bAR_ID)
        //{
        //    var bAR_IDParameter = bAR_ID.HasValue ?
        //        new ObjectParameter("BAR_ID", bAR_ID) :
        //        new ObjectParameter("BAR_ID", typeof(long));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("barcode_delete", bAR_IDParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> barcode_get_max_number_of_date(Nullable<System.DateTime> aPPLY_DATE)
        //{
        //    var aPPLY_DATEParameter = aPPLY_DATE.HasValue ?
        //        new ObjectParameter("APPLY_DATE", aPPLY_DATE) :
        //        new ObjectParameter("APPLY_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("barcode_get_max_number_of_date", aPPLY_DATEParameter);
        //}

        //public virtual ObjectResult<barcode_GetTop5000desc_Result> barcode_GetTop5000desc()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<barcode_GetTop5000desc_Result>("barcode_GetTop5000desc");
        //}

        //public virtual ObjectResult<Nullable<long>> barcode_insert(Nullable<long> bAR_ID, Nullable<int> cT_ID, Nullable<int> tYPEID, Nullable<int> zONE_ID, string bAR_NO, Nullable<int> aCC_ID, Nullable<bool> aCTIVE, Nullable<bool> uSED, Nullable<int> nUMBER, Nullable<System.DateTime> aPPLY_DATE)
        //{
        //    var bAR_IDParameter = bAR_ID.HasValue ?
        //        new ObjectParameter("BAR_ID", bAR_ID) :
        //        new ObjectParameter("BAR_ID", typeof(long));

        //    var cT_IDParameter = cT_ID.HasValue ?
        //        new ObjectParameter("CT_ID", cT_ID) :
        //        new ObjectParameter("CT_ID", typeof(int));

        //    var tYPEIDParameter = tYPEID.HasValue ?
        //        new ObjectParameter("TYPEID", tYPEID) :
        //        new ObjectParameter("TYPEID", typeof(int));

        //    var zONE_IDParameter = zONE_ID.HasValue ?
        //        new ObjectParameter("ZONE_ID", zONE_ID) :
        //        new ObjectParameter("ZONE_ID", typeof(int));

        //    var bAR_NOParameter = bAR_NO != null ?
        //        new ObjectParameter("BAR_NO", bAR_NO) :
        //        new ObjectParameter("BAR_NO", typeof(string));

        //    var aCC_IDParameter = aCC_ID.HasValue ?
        //        new ObjectParameter("ACC_ID", aCC_ID) :
        //        new ObjectParameter("ACC_ID", typeof(int));

        //    var aCTIVEParameter = aCTIVE.HasValue ?
        //        new ObjectParameter("ACTIVE", aCTIVE) :
        //        new ObjectParameter("ACTIVE", typeof(bool));

        //    var uSEDParameter = uSED.HasValue ?
        //        new ObjectParameter("USED", uSED) :
        //        new ObjectParameter("USED", typeof(bool));

        //    var nUMBERParameter = nUMBER.HasValue ?
        //        new ObjectParameter("NUMBER", nUMBER) :
        //        new ObjectParameter("NUMBER", typeof(int));

        //    var aPPLY_DATEParameter = aPPLY_DATE.HasValue ?
        //        new ObjectParameter("APPLY_DATE", aPPLY_DATE) :
        //        new ObjectParameter("APPLY_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("barcode_insert", bAR_IDParameter, cT_IDParameter, tYPEIDParameter, zONE_IDParameter, bAR_NOParameter, aCC_IDParameter, aCTIVEParameter, uSEDParameter, nUMBERParameter, aPPLY_DATEParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> barcode_IsExist(string bAR_NO)
        //{
        //    var bAR_NOParameter = bAR_NO != null ?
        //        new ObjectParameter("BAR_NO", bAR_NO) :
        //        new ObjectParameter("BAR_NO", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("barcode_IsExist", bAR_NOParameter);
        //}

        //public virtual ObjectResult<barcode_isExistAndInfo_Result> barcode_isExistAndInfo(string bAR_NO)
        //{
        //    var bAR_NOParameter = bAR_NO != null ?
        //        new ObjectParameter("BAR_NO", bAR_NO) :
        //        new ObjectParameter("BAR_NO", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<barcode_isExistAndInfo_Result>("barcode_isExistAndInfo", bAR_NOParameter);
        //}

        //public virtual int barcode_update(Nullable<long> bAR_ID, Nullable<bool> aCTIVE, Nullable<bool> uSED)
        //{
        //    var bAR_IDParameter = bAR_ID.HasValue ?
        //        new ObjectParameter("BAR_ID", bAR_ID) :
        //        new ObjectParameter("BAR_ID", typeof(long));

        //    var aCTIVEParameter = aCTIVE.HasValue ?
        //        new ObjectParameter("ACTIVE", aCTIVE) :
        //        new ObjectParameter("ACTIVE", typeof(bool));

        //    var uSEDParameter = uSED.HasValue ?
        //        new ObjectParameter("USED", uSED) :
        //        new ObjectParameter("USED", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("barcode_update", bAR_IDParameter, aCTIVEParameter, uSEDParameter);
        //}

        //public virtual int barcode_UpdateDamage(Nullable<long> bAR_ID, Nullable<bool> dAMAGE)
        //{
        //    var bAR_IDParameter = bAR_ID.HasValue ?
        //        new ObjectParameter("BAR_ID", bAR_ID) :
        //        new ObjectParameter("BAR_ID", typeof(long));

        //    var dAMAGEParameter = dAMAGE.HasValue ?
        //        new ObjectParameter("DAMAGE", dAMAGE) :
        //        new ObjectParameter("DAMAGE", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("barcode_UpdateDamage", bAR_IDParameter, dAMAGEParameter);
        //}

        //public virtual ObjectResult<string> common_GetDate()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("common_GetDate");
        //}

        //public virtual ObjectResult<string> common_GetDate_test()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("common_GetDate_test");
        //}

        //public virtual int department_Delete(Nullable<int> dEP_ID)
        //{
        //    var dEP_IDParameter = dEP_ID.HasValue ?
        //        new ObjectParameter("DEP_ID", dEP_ID) :
        //        new ObjectParameter("DEP_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("department_Delete", dEP_IDParameter);
        //}

        //public virtual ObjectResult<department_GetAll_Result> department_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<department_GetAll_Result>("department_GetAll");
        //}

        //public virtual ObjectResult<Nullable<int>> department_insert(Nullable<int> dEP_ID, string dEP_NAME, string dEP_DESCRIPTION, Nullable<bool> dEP_STATUS)
        //{
        //    var dEP_IDParameter = dEP_ID.HasValue ?
        //        new ObjectParameter("DEP_ID", dEP_ID) :
        //        new ObjectParameter("DEP_ID", typeof(int));

        //    var dEP_NAMEParameter = dEP_NAME != null ?
        //        new ObjectParameter("DEP_NAME", dEP_NAME) :
        //        new ObjectParameter("DEP_NAME", typeof(string));

        //    var dEP_DESCRIPTIONParameter = dEP_DESCRIPTION != null ?
        //        new ObjectParameter("DEP_DESCRIPTION", dEP_DESCRIPTION) :
        //        new ObjectParameter("DEP_DESCRIPTION", typeof(string));

        //    var dEP_STATUSParameter = dEP_STATUS.HasValue ?
        //        new ObjectParameter("DEP_STATUS", dEP_STATUS) :
        //        new ObjectParameter("DEP_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("department_insert", dEP_IDParameter, dEP_NAMEParameter, dEP_DESCRIPTIONParameter, dEP_STATUSParameter);
        //}

        //public virtual int department_update(Nullable<int> dEP_ID, string dEP_NAME, string dEP_DESCRIPTION, Nullable<bool> dEP_STATUS)
        //{
        //    var dEP_IDParameter = dEP_ID.HasValue ?
        //        new ObjectParameter("DEP_ID", dEP_ID) :
        //        new ObjectParameter("DEP_ID", typeof(int));

        //    var dEP_NAMEParameter = dEP_NAME != null ?
        //        new ObjectParameter("DEP_NAME", dEP_NAME) :
        //        new ObjectParameter("DEP_NAME", typeof(string));

        //    var dEP_DESCRIPTIONParameter = dEP_DESCRIPTION != null ?
        //        new ObjectParameter("DEP_DESCRIPTION", dEP_DESCRIPTION) :
        //        new ObjectParameter("DEP_DESCRIPTION", typeof(string));

        //    var dEP_STATUSParameter = dEP_STATUS.HasValue ?
        //        new ObjectParameter("DEP_STATUS", dEP_STATUS) :
        //        new ObjectParameter("DEP_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("department_update", dEP_IDParameter, dEP_NAMEParameter, dEP_DESCRIPTIONParameter, dEP_STATUSParameter);
        //}

        //public virtual int detail_sale_delete(Nullable<long> dTS_ID)
        //{
        //    var dTS_IDParameter = dTS_ID.HasValue ?
        //        new ObjectParameter("DTS_ID", dTS_ID) :
        //        new ObjectParameter("DTS_ID", typeof(long));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("detail_sale_delete", dTS_IDParameter);
        //}

        //public virtual ObjectResult<detail_sale_getAll_Result> detail_sale_getAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<detail_sale_getAll_Result>("detail_sale_getAll");
        //}

        //public virtual ObjectResult<Nullable<long>> detail_sale_insert(Nullable<long> dTS_ID, Nullable<long> tS_ID, Nullable<int> cA_ID, Nullable<long> bAR_ID, Nullable<long> dTS_PRICE, Nullable<long> dTS_PAY)
        //{
        //    var dTS_IDParameter = dTS_ID.HasValue ?
        //        new ObjectParameter("DTS_ID", dTS_ID) :
        //        new ObjectParameter("DTS_ID", typeof(long));

        //    var tS_IDParameter = tS_ID.HasValue ?
        //        new ObjectParameter("TS_ID", tS_ID) :
        //        new ObjectParameter("TS_ID", typeof(long));

        //    var cA_IDParameter = cA_ID.HasValue ?
        //        new ObjectParameter("CA_ID", cA_ID) :
        //        new ObjectParameter("CA_ID", typeof(int));

        //    var bAR_IDParameter = bAR_ID.HasValue ?
        //        new ObjectParameter("BAR_ID", bAR_ID) :
        //        new ObjectParameter("BAR_ID", typeof(long));

        //    var dTS_PRICEParameter = dTS_PRICE.HasValue ?
        //        new ObjectParameter("DTS_PRICE", dTS_PRICE) :
        //        new ObjectParameter("DTS_PRICE", typeof(long));

        //    var dTS_PAYParameter = dTS_PAY.HasValue ?
        //        new ObjectParameter("DTS_PAY", dTS_PAY) :
        //        new ObjectParameter("DTS_PAY", typeof(long));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("detail_sale_insert", dTS_IDParameter, tS_IDParameter, cA_IDParameter, bAR_IDParameter, dTS_PRICEParameter, dTS_PAYParameter);
        //}

        //public virtual int detail_sale_update(Nullable<long> dTS_ID, Nullable<long> tS_ID, Nullable<int> cA_ID, Nullable<long> bAR_ID, Nullable<long> dTS_PRICE, Nullable<long> dTS_PAY)
        //{
        //    var dTS_IDParameter = dTS_ID.HasValue ?
        //        new ObjectParameter("DTS_ID", dTS_ID) :
        //        new ObjectParameter("DTS_ID", typeof(long));

        //    var tS_IDParameter = tS_ID.HasValue ?
        //        new ObjectParameter("TS_ID", tS_ID) :
        //        new ObjectParameter("TS_ID", typeof(long));

        //    var cA_IDParameter = cA_ID.HasValue ?
        //        new ObjectParameter("CA_ID", cA_ID) :
        //        new ObjectParameter("CA_ID", typeof(int));

        //    var bAR_IDParameter = bAR_ID.HasValue ?
        //        new ObjectParameter("BAR_ID", bAR_ID) :
        //        new ObjectParameter("BAR_ID", typeof(long));

        //    var dTS_PRICEParameter = dTS_PRICE.HasValue ?
        //        new ObjectParameter("DTS_PRICE", dTS_PRICE) :
        //        new ObjectParameter("DTS_PRICE", typeof(long));

        //    var dTS_PAYParameter = dTS_PAY.HasValue ?
        //        new ObjectParameter("DTS_PAY", dTS_PAY) :
        //        new ObjectParameter("DTS_PAY", typeof(long));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("detail_sale_update", dTS_IDParameter, tS_IDParameter, cA_IDParameter, bAR_IDParameter, dTS_PRICEParameter, dTS_PAYParameter);
        //}

        //public virtual int device_Delete(Nullable<int> dEVICE_ID)
        //{
        //    var dEVICE_IDParameter = dEVICE_ID.HasValue ?
        //        new ObjectParameter("DEVICE_ID", dEVICE_ID) :
        //        new ObjectParameter("DEVICE_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("device_Delete", dEVICE_IDParameter);
        //}

        //public virtual ObjectResult<device_GetAll_Result> device_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<device_GetAll_Result>("device_GetAll");
        //}

        //public virtual ObjectResult<device_GetAll_Visible_Result> device_GetAll_Visible()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<device_GetAll_Visible_Result>("device_GetAll_Visible");
        //}

        //public virtual ObjectResult<Nullable<int>> device_insert(Nullable<int> dEVICE_ID, string dEVICE_NAME, string dEVICE_CODE, Nullable<int> dT_ID, Nullable<int> zONE_ID, string dEVICE_MAC, string dEVICE_IP, Nullable<int> dEVICE_PORT, string dEVICE_DES, Nullable<bool> dEVICE_STATUS)
        //{
        //    var dEVICE_IDParameter = dEVICE_ID.HasValue ?
        //        new ObjectParameter("DEVICE_ID", dEVICE_ID) :
        //        new ObjectParameter("DEVICE_ID", typeof(int));

        //    var dEVICE_NAMEParameter = dEVICE_NAME != null ?
        //        new ObjectParameter("DEVICE_NAME", dEVICE_NAME) :
        //        new ObjectParameter("DEVICE_NAME", typeof(string));

        //    var dEVICE_CODEParameter = dEVICE_CODE != null ?
        //        new ObjectParameter("DEVICE_CODE", dEVICE_CODE) :
        //        new ObjectParameter("DEVICE_CODE", typeof(string));

        //    var dT_IDParameter = dT_ID.HasValue ?
        //        new ObjectParameter("DT_ID", dT_ID) :
        //        new ObjectParameter("DT_ID", typeof(int));

        //    var zONE_IDParameter = zONE_ID.HasValue ?
        //        new ObjectParameter("ZONE_ID", zONE_ID) :
        //        new ObjectParameter("ZONE_ID", typeof(int));

        //    var dEVICE_MACParameter = dEVICE_MAC != null ?
        //        new ObjectParameter("DEVICE_MAC", dEVICE_MAC) :
        //        new ObjectParameter("DEVICE_MAC", typeof(string));

        //    var dEVICE_IPParameter = dEVICE_IP != null ?
        //        new ObjectParameter("DEVICE_IP", dEVICE_IP) :
        //        new ObjectParameter("DEVICE_IP", typeof(string));

        //    var dEVICE_PORTParameter = dEVICE_PORT.HasValue ?
        //        new ObjectParameter("DEVICE_PORT", dEVICE_PORT) :
        //        new ObjectParameter("DEVICE_PORT", typeof(int));

        //    var dEVICE_DESParameter = dEVICE_DES != null ?
        //        new ObjectParameter("DEVICE_DES", dEVICE_DES) :
        //        new ObjectParameter("DEVICE_DES", typeof(string));

        //    var dEVICE_STATUSParameter = dEVICE_STATUS.HasValue ?
        //        new ObjectParameter("DEVICE_STATUS", dEVICE_STATUS) :
        //        new ObjectParameter("DEVICE_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("device_insert", dEVICE_IDParameter, dEVICE_NAMEParameter, dEVICE_CODEParameter, dT_IDParameter, zONE_IDParameter, dEVICE_MACParameter, dEVICE_IPParameter, dEVICE_PORTParameter, dEVICE_DESParameter, dEVICE_STATUSParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> device_IsExist(string dEVICE_CODE)
        //{
        //    var dEVICE_CODEParameter = dEVICE_CODE != null ?
        //        new ObjectParameter("DEVICE_CODE", dEVICE_CODE) :
        //        new ObjectParameter("DEVICE_CODE", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("device_IsExist", dEVICE_CODEParameter);
        //}

        //public virtual int device_type_Delete(Nullable<int> dT_ID)
        //{
        //    var dT_IDParameter = dT_ID.HasValue ?
        //        new ObjectParameter("DT_ID", dT_ID) :
        //        new ObjectParameter("DT_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("device_type_Delete", dT_IDParameter);
        //}

        //public virtual ObjectResult<device_type_GetAll_Result> device_type_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<device_type_GetAll_Result>("device_type_GetAll");
        //}

        //public virtual ObjectResult<Nullable<int>> device_type_insert(Nullable<int> dT_ID, string dT_NAME, string dT_CODE, string dT_DES, Nullable<bool> dT_STATUS)
        //{
        //    var dT_IDParameter = dT_ID.HasValue ?
        //        new ObjectParameter("DT_ID", dT_ID) :
        //        new ObjectParameter("DT_ID", typeof(int));

        //    var dT_NAMEParameter = dT_NAME != null ?
        //        new ObjectParameter("DT_NAME", dT_NAME) :
        //        new ObjectParameter("DT_NAME", typeof(string));

        //    var dT_CODEParameter = dT_CODE != null ?
        //        new ObjectParameter("DT_CODE", dT_CODE) :
        //        new ObjectParameter("DT_CODE", typeof(string));

        //    var dT_DESParameter = dT_DES != null ?
        //        new ObjectParameter("DT_DES", dT_DES) :
        //        new ObjectParameter("DT_DES", typeof(string));

        //    var dT_STATUSParameter = dT_STATUS.HasValue ?
        //        new ObjectParameter("DT_STATUS", dT_STATUS) :
        //        new ObjectParameter("DT_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("device_type_insert", dT_IDParameter, dT_NAMEParameter, dT_CODEParameter, dT_DESParameter, dT_STATUSParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> device_type_IsExist(string dT_CODE)
        //{
        //    var dT_CODEParameter = dT_CODE != null ?
        //        new ObjectParameter("DT_CODE", dT_CODE) :
        //        new ObjectParameter("DT_CODE", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("device_type_IsExist", dT_CODEParameter);
        //}

        //public virtual int device_type_update(Nullable<int> dT_ID, string dT_NAME, string dT_CODE, string dT_DES, Nullable<bool> dT_STATUS)
        //{
        //    var dT_IDParameter = dT_ID.HasValue ?
        //        new ObjectParameter("DT_ID", dT_ID) :
        //        new ObjectParameter("DT_ID", typeof(int));

        //    var dT_NAMEParameter = dT_NAME != null ?
        //        new ObjectParameter("DT_NAME", dT_NAME) :
        //        new ObjectParameter("DT_NAME", typeof(string));

        //    var dT_CODEParameter = dT_CODE != null ?
        //        new ObjectParameter("DT_CODE", dT_CODE) :
        //        new ObjectParameter("DT_CODE", typeof(string));

        //    var dT_DESParameter = dT_DES != null ?
        //        new ObjectParameter("DT_DES", dT_DES) :
        //        new ObjectParameter("DT_DES", typeof(string));

        //    var dT_STATUSParameter = dT_STATUS.HasValue ?
        //        new ObjectParameter("DT_STATUS", dT_STATUS) :
        //        new ObjectParameter("DT_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("device_type_update", dT_IDParameter, dT_NAMEParameter, dT_CODEParameter, dT_DESParameter, dT_STATUSParameter);
        //}

        //public virtual int device_update(Nullable<int> dEVICE_ID, string dEVICE_NAME, string dEVICE_CODE, Nullable<int> dT_ID, Nullable<int> zONE_ID, string dEVICE_IP, string dEVICE_MAC, Nullable<int> dEVICE_PORT, string dEVICE_DES, Nullable<bool> dEVICE_STATUS)
        //{
        //    var dEVICE_IDParameter = dEVICE_ID.HasValue ?
        //        new ObjectParameter("DEVICE_ID", dEVICE_ID) :
        //        new ObjectParameter("DEVICE_ID", typeof(int));

        //    var dEVICE_NAMEParameter = dEVICE_NAME != null ?
        //        new ObjectParameter("DEVICE_NAME", dEVICE_NAME) :
        //        new ObjectParameter("DEVICE_NAME", typeof(string));

        //    var dEVICE_CODEParameter = dEVICE_CODE != null ?
        //        new ObjectParameter("DEVICE_CODE", dEVICE_CODE) :
        //        new ObjectParameter("DEVICE_CODE", typeof(string));

        //    var dT_IDParameter = dT_ID.HasValue ?
        //        new ObjectParameter("DT_ID", dT_ID) :
        //        new ObjectParameter("DT_ID", typeof(int));

        //    var zONE_IDParameter = zONE_ID.HasValue ?
        //        new ObjectParameter("ZONE_ID", zONE_ID) :
        //        new ObjectParameter("ZONE_ID", typeof(int));

        //    var dEVICE_IPParameter = dEVICE_IP != null ?
        //        new ObjectParameter("DEVICE_IP", dEVICE_IP) :
        //        new ObjectParameter("DEVICE_IP", typeof(string));

        //    var dEVICE_MACParameter = dEVICE_MAC != null ?
        //        new ObjectParameter("DEVICE_MAC", dEVICE_MAC) :
        //        new ObjectParameter("DEVICE_MAC", typeof(string));

        //    var dEVICE_PORTParameter = dEVICE_PORT.HasValue ?
        //        new ObjectParameter("DEVICE_PORT", dEVICE_PORT) :
        //        new ObjectParameter("DEVICE_PORT", typeof(int));

        //    var dEVICE_DESParameter = dEVICE_DES != null ?
        //        new ObjectParameter("DEVICE_DES", dEVICE_DES) :
        //        new ObjectParameter("DEVICE_DES", typeof(string));

        //    var dEVICE_STATUSParameter = dEVICE_STATUS.HasValue ?
        //        new ObjectParameter("DEVICE_STATUS", dEVICE_STATUS) :
        //        new ObjectParameter("DEVICE_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("device_update", dEVICE_IDParameter, dEVICE_NAMEParameter, dEVICE_CODEParameter, dT_IDParameter, zONE_IDParameter, dEVICE_IPParameter, dEVICE_MACParameter, dEVICE_PORTParameter, dEVICE_DESParameter, dEVICE_STATUSParameter);
        //}

        //public virtual int discount_delete(Nullable<int> dISC_ID)
        //{
        //    var dISC_IDParameter = dISC_ID.HasValue ?
        //        new ObjectParameter("DISC_ID", dISC_ID) :
        //        new ObjectParameter("DISC_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("discount_delete", dISC_IDParameter);
        //}

        //public virtual ObjectResult<discount_FindByHol_Result> discount_FindByHol(Nullable<int> hOL_ID, Nullable<int> tF_ID)
        //{
        //    var hOL_IDParameter = hOL_ID.HasValue ?
        //        new ObjectParameter("HOL_ID", hOL_ID) :
        //        new ObjectParameter("HOL_ID", typeof(int));

        //    var tF_IDParameter = tF_ID.HasValue ?
        //        new ObjectParameter("TF_ID", tF_ID) :
        //        new ObjectParameter("TF_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<discount_FindByHol_Result>("discount_FindByHol", hOL_IDParameter, tF_IDParameter);
        //}

        //public virtual ObjectResult<discount_FindByWeek_Result> discount_FindByWeek(Nullable<bool> wD_ISWEEKEND, Nullable<int> tF_ID)
        //{
        //    var wD_ISWEEKENDParameter = wD_ISWEEKEND.HasValue ?
        //        new ObjectParameter("WD_ISWEEKEND", wD_ISWEEKEND) :
        //        new ObjectParameter("WD_ISWEEKEND", typeof(bool));

        //    var tF_IDParameter = tF_ID.HasValue ?
        //        new ObjectParameter("TF_ID", tF_ID) :
        //        new ObjectParameter("TF_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<discount_FindByWeek_Result>("discount_FindByWeek", wD_ISWEEKENDParameter, tF_IDParameter);
        //}

        //public virtual ObjectResult<discount_GetAll_Result> discount_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<discount_GetAll_Result>("discount_GetAll");
        //}

        //public virtual ObjectResult<discount_GetAllVisible_Result> discount_GetAllVisible()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<discount_GetAllVisible_Result>("discount_GetAllVisible");
        //}

        //public virtual ObjectResult<discount_GetInfoById_Result> discount_GetInfoById(Nullable<int> dISC_ID)
        //{
        //    var dISC_IDParameter = dISC_ID.HasValue ?
        //        new ObjectParameter("DISC_ID", dISC_ID) :
        //        new ObjectParameter("DISC_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<discount_GetInfoById_Result>("discount_GetInfoById", dISC_IDParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> discount_GetTypeById(Nullable<int> dISC_ID)
        //{
        //    var dISC_IDParameter = dISC_ID.HasValue ?
        //        new ObjectParameter("DISC_ID", dISC_ID) :
        //        new ObjectParameter("DISC_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("discount_GetTypeById", dISC_IDParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> discount_insert(Nullable<int> dISC_ID, Nullable<int> dISCT_ID, Nullable<int> hOL_ID, Nullable<int> tF_ID, string dISC_NAME, string dISC_CODE, Nullable<bool> wD_ISWEEKEND, Nullable<int> dISC_VALUE, string dISC_DES, Nullable<System.DateTime> cREATE_DATE, Nullable<System.DateTime> dISC_START, Nullable<System.DateTime> dISC_END, Nullable<bool> dISC_STATUS)
        //{
        //    var dISC_IDParameter = dISC_ID.HasValue ?
        //        new ObjectParameter("DISC_ID", dISC_ID) :
        //        new ObjectParameter("DISC_ID", typeof(int));

        //    var dISCT_IDParameter = dISCT_ID.HasValue ?
        //        new ObjectParameter("DISCT_ID", dISCT_ID) :
        //        new ObjectParameter("DISCT_ID", typeof(int));

        //    var hOL_IDParameter = hOL_ID.HasValue ?
        //        new ObjectParameter("HOL_ID", hOL_ID) :
        //        new ObjectParameter("HOL_ID", typeof(int));

        //    var tF_IDParameter = tF_ID.HasValue ?
        //        new ObjectParameter("TF_ID", tF_ID) :
        //        new ObjectParameter("TF_ID", typeof(int));

        //    var dISC_NAMEParameter = dISC_NAME != null ?
        //        new ObjectParameter("DISC_NAME", dISC_NAME) :
        //        new ObjectParameter("DISC_NAME", typeof(string));

        //    var dISC_CODEParameter = dISC_CODE != null ?
        //        new ObjectParameter("DISC_CODE", dISC_CODE) :
        //        new ObjectParameter("DISC_CODE", typeof(string));

        //    var wD_ISWEEKENDParameter = wD_ISWEEKEND.HasValue ?
        //        new ObjectParameter("WD_ISWEEKEND", wD_ISWEEKEND) :
        //        new ObjectParameter("WD_ISWEEKEND", typeof(bool));

        //    var dISC_VALUEParameter = dISC_VALUE.HasValue ?
        //        new ObjectParameter("DISC_VALUE", dISC_VALUE) :
        //        new ObjectParameter("DISC_VALUE", typeof(int));

        //    var dISC_DESParameter = dISC_DES != null ?
        //        new ObjectParameter("DISC_DES", dISC_DES) :
        //        new ObjectParameter("DISC_DES", typeof(string));

        //    var cREATE_DATEParameter = cREATE_DATE.HasValue ?
        //        new ObjectParameter("CREATE_DATE", cREATE_DATE) :
        //        new ObjectParameter("CREATE_DATE", typeof(System.DateTime));

        //    var dISC_STARTParameter = dISC_START.HasValue ?
        //        new ObjectParameter("DISC_START", dISC_START) :
        //        new ObjectParameter("DISC_START", typeof(System.DateTime));

        //    var dISC_ENDParameter = dISC_END.HasValue ?
        //        new ObjectParameter("DISC_END", dISC_END) :
        //        new ObjectParameter("DISC_END", typeof(System.DateTime));

        //    var dISC_STATUSParameter = dISC_STATUS.HasValue ?
        //        new ObjectParameter("DISC_STATUS", dISC_STATUS) :
        //        new ObjectParameter("DISC_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("discount_insert", dISC_IDParameter, dISCT_IDParameter, hOL_IDParameter, tF_IDParameter, dISC_NAMEParameter, dISC_CODEParameter, wD_ISWEEKENDParameter, dISC_VALUEParameter, dISC_DESParameter, cREATE_DATEParameter, dISC_STARTParameter, dISC_ENDParameter, dISC_STATUSParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> discount_IsExist(string dISC_CODE)
        //{
        //    var dISC_CODEParameter = dISC_CODE != null ?
        //        new ObjectParameter("DISC_CODE", dISC_CODE) :
        //        new ObjectParameter("DISC_CODE", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("discount_IsExist", dISC_CODEParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> discount_isExistsType(Nullable<int> dISCT_ID, Nullable<int> hOL_ID, Nullable<int> tF_ID, Nullable<bool> wD_ISWEEKEND)
        //{
        //    var dISCT_IDParameter = dISCT_ID.HasValue ?
        //        new ObjectParameter("DISCT_ID", dISCT_ID) :
        //        new ObjectParameter("DISCT_ID", typeof(int));

        //    var hOL_IDParameter = hOL_ID.HasValue ?
        //        new ObjectParameter("HOL_ID", hOL_ID) :
        //        new ObjectParameter("HOL_ID", typeof(int));

        //    var tF_IDParameter = tF_ID.HasValue ?
        //        new ObjectParameter("TF_ID", tF_ID) :
        //        new ObjectParameter("TF_ID", typeof(int));

        //    var wD_ISWEEKENDParameter = wD_ISWEEKEND.HasValue ?
        //        new ObjectParameter("WD_ISWEEKEND", wD_ISWEEKEND) :
        //        new ObjectParameter("WD_ISWEEKEND", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("discount_isExistsType", dISCT_IDParameter, hOL_IDParameter, tF_IDParameter, wD_ISWEEKENDParameter);
        //}

        //public virtual int discount_type_delete(Nullable<int> dISCT_ID)
        //{
        //    var dISCT_IDParameter = dISCT_ID.HasValue ?
        //        new ObjectParameter("DISCT_ID", dISCT_ID) :
        //        new ObjectParameter("DISCT_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("discount_type_delete", dISCT_IDParameter);
        //}

        //public virtual ObjectResult<discount_type_GetAll_Result> discount_type_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<discount_type_GetAll_Result>("discount_type_GetAll");
        //}

        //public virtual ObjectResult<Nullable<int>> discount_type_insert(Nullable<int> dISCT_ID, string dISCT_NAME, Nullable<int> dISCT_CHECK, string dISCT_DES)
        //{
        //    var dISCT_IDParameter = dISCT_ID.HasValue ?
        //        new ObjectParameter("DISCT_ID", dISCT_ID) :
        //        new ObjectParameter("DISCT_ID", typeof(int));

        //    var dISCT_NAMEParameter = dISCT_NAME != null ?
        //        new ObjectParameter("DISCT_NAME", dISCT_NAME) :
        //        new ObjectParameter("DISCT_NAME", typeof(string));

        //    var dISCT_CHECKParameter = dISCT_CHECK.HasValue ?
        //        new ObjectParameter("DISCT_CHECK", dISCT_CHECK) :
        //        new ObjectParameter("DISCT_CHECK", typeof(int));

        //    var dISCT_DESParameter = dISCT_DES != null ?
        //        new ObjectParameter("DISCT_DES", dISCT_DES) :
        //        new ObjectParameter("DISCT_DES", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("discount_type_insert", dISCT_IDParameter, dISCT_NAMEParameter, dISCT_CHECKParameter, dISCT_DESParameter);
        //}

        //public virtual int discount_type_update(Nullable<int> dISCT_ID, string dISCT_NAME, Nullable<int> dISCT_CHECK, string dISCT_DES)
        //{
        //    var dISCT_IDParameter = dISCT_ID.HasValue ?
        //        new ObjectParameter("DISCT_ID", dISCT_ID) :
        //        new ObjectParameter("DISCT_ID", typeof(int));

        //    var dISCT_NAMEParameter = dISCT_NAME != null ?
        //        new ObjectParameter("DISCT_NAME", dISCT_NAME) :
        //        new ObjectParameter("DISCT_NAME", typeof(string));

        //    var dISCT_CHECKParameter = dISCT_CHECK.HasValue ?
        //        new ObjectParameter("DISCT_CHECK", dISCT_CHECK) :
        //        new ObjectParameter("DISCT_CHECK", typeof(int));

        //    var dISCT_DESParameter = dISCT_DES != null ?
        //        new ObjectParameter("DISCT_DES", dISCT_DES) :
        //        new ObjectParameter("DISCT_DES", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("discount_type_update", dISCT_IDParameter, dISCT_NAMEParameter, dISCT_CHECKParameter, dISCT_DESParameter);
        //}

        //public virtual int discount_update(Nullable<int> dISC_ID, Nullable<int> dISCT_ID, Nullable<int> hOL_ID, Nullable<int> tF_ID, Nullable<bool> wD_ISWEEKEND)
        //{
        //    var dISC_IDParameter = dISC_ID.HasValue ?
        //        new ObjectParameter("DISC_ID", dISC_ID) :
        //        new ObjectParameter("DISC_ID", typeof(int));

        //    var dISCT_IDParameter = dISCT_ID.HasValue ?
        //        new ObjectParameter("DISCT_ID", dISCT_ID) :
        //        new ObjectParameter("DISCT_ID", typeof(int));

        //    var hOL_IDParameter = hOL_ID.HasValue ?
        //        new ObjectParameter("HOL_ID", hOL_ID) :
        //        new ObjectParameter("HOL_ID", typeof(int));

        //    var tF_IDParameter = tF_ID.HasValue ?
        //        new ObjectParameter("TF_ID", tF_ID) :
        //        new ObjectParameter("TF_ID", typeof(int));

        //    var wD_ISWEEKENDParameter = wD_ISWEEKEND.HasValue ?
        //        new ObjectParameter("WD_ISWEEKEND", wD_ISWEEKEND) :
        //        new ObjectParameter("WD_ISWEEKEND", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("discount_update", dISC_IDParameter, dISCT_IDParameter, hOL_IDParameter, tF_IDParameter, wD_ISWEEKENDParameter);
        //}

        //public virtual int employees_Delete(Nullable<int> eM_ID)
        //{
        //    var eM_IDParameter = eM_ID.HasValue ?
        //        new ObjectParameter("EM_ID", eM_ID) :
        //        new ObjectParameter("EM_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("employees_Delete", eM_IDParameter);
        //}

        //public virtual ObjectResult<employees_GetAll_Result> employees_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<employees_GetAll_Result>("employees_GetAll");
        //}

        //public virtual ObjectResult<employees_GetAll_Visible_Result> employees_GetAll_Visible()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<employees_GetAll_Visible_Result>("employees_GetAll_Visible");
        //}

        //public virtual ObjectResult<Nullable<int>> employees_GetLastestID(string eM_NAME, string pHONE)
        //{
        //    var eM_NAMEParameter = eM_NAME != null ?
        //        new ObjectParameter("EM_NAME", eM_NAME) :
        //        new ObjectParameter("EM_NAME", typeof(string));

        //    var pHONEParameter = pHONE != null ?
        //        new ObjectParameter("PHONE", pHONE) :
        //        new ObjectParameter("PHONE", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("employees_GetLastestID", eM_NAMEParameter, pHONEParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> employees_insert(Nullable<int> eM_ID, Nullable<int> dEP_ID, string eM_NAME, string eM_CODE, string pHONE, string iDENTITY_NUMBER, string sEX, string aDDRESS, string dESCRIPTION, byte[] iMAGE, Nullable<bool> eM_STATUS)
        //{
        //    var eM_IDParameter = eM_ID.HasValue ?
        //        new ObjectParameter("EM_ID", eM_ID) :
        //        new ObjectParameter("EM_ID", typeof(int));

        //    var dEP_IDParameter = dEP_ID.HasValue ?
        //        new ObjectParameter("DEP_ID", dEP_ID) :
        //        new ObjectParameter("DEP_ID", typeof(int));

        //    var eM_NAMEParameter = eM_NAME != null ?
        //        new ObjectParameter("EM_NAME", eM_NAME) :
        //        new ObjectParameter("EM_NAME", typeof(string));

        //    var eM_CODEParameter = eM_CODE != null ?
        //        new ObjectParameter("EM_CODE", eM_CODE) :
        //        new ObjectParameter("EM_CODE", typeof(string));

        //    var pHONEParameter = pHONE != null ?
        //        new ObjectParameter("PHONE", pHONE) :
        //        new ObjectParameter("PHONE", typeof(string));

        //    var iDENTITY_NUMBERParameter = iDENTITY_NUMBER != null ?
        //        new ObjectParameter("IDENTITY_NUMBER", iDENTITY_NUMBER) :
        //        new ObjectParameter("IDENTITY_NUMBER", typeof(string));

        //    var sEXParameter = sEX != null ?
        //        new ObjectParameter("SEX", sEX) :
        //        new ObjectParameter("SEX", typeof(string));

        //    var aDDRESSParameter = aDDRESS != null ?
        //        new ObjectParameter("ADDRESS", aDDRESS) :
        //        new ObjectParameter("ADDRESS", typeof(string));

        //    var dESCRIPTIONParameter = dESCRIPTION != null ?
        //        new ObjectParameter("DESCRIPTION", dESCRIPTION) :
        //        new ObjectParameter("DESCRIPTION", typeof(string));

        //    var iMAGEParameter = iMAGE != null ?
        //        new ObjectParameter("IMAGE", iMAGE) :
        //        new ObjectParameter("IMAGE", typeof(byte[]));

        //    var eM_STATUSParameter = eM_STATUS.HasValue ?
        //        new ObjectParameter("EM_STATUS", eM_STATUS) :
        //        new ObjectParameter("EM_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("employees_insert", eM_IDParameter, dEP_IDParameter, eM_NAMEParameter, eM_CODEParameter, pHONEParameter, iDENTITY_NUMBERParameter, sEXParameter, aDDRESSParameter, dESCRIPTIONParameter, iMAGEParameter, eM_STATUSParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> employees_IsExist(string eM_CODE)
        //{
        //    var eM_CODEParameter = eM_CODE != null ?
        //        new ObjectParameter("EM_CODE", eM_CODE) :
        //        new ObjectParameter("EM_CODE", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("employees_IsExist", eM_CODEParameter);
        //}

        //public virtual int employees_update(Nullable<int> eM_ID, Nullable<int> dEP_ID, string eM_NAME, string eM_CODE, string pHONE, string iDENTITY_NUMBER, string sEX, string aDDRESS, string dESCRIPTION, byte[] iMAGE, Nullable<bool> eM_STATUS)
        //{
        //    var eM_IDParameter = eM_ID.HasValue ?
        //        new ObjectParameter("EM_ID", eM_ID) :
        //        new ObjectParameter("EM_ID", typeof(int));

        //    var dEP_IDParameter = dEP_ID.HasValue ?
        //        new ObjectParameter("DEP_ID", dEP_ID) :
        //        new ObjectParameter("DEP_ID", typeof(int));

        //    var eM_NAMEParameter = eM_NAME != null ?
        //        new ObjectParameter("EM_NAME", eM_NAME) :
        //        new ObjectParameter("EM_NAME", typeof(string));

        //    var eM_CODEParameter = eM_CODE != null ?
        //        new ObjectParameter("EM_CODE", eM_CODE) :
        //        new ObjectParameter("EM_CODE", typeof(string));

        //    var pHONEParameter = pHONE != null ?
        //        new ObjectParameter("PHONE", pHONE) :
        //        new ObjectParameter("PHONE", typeof(string));

        //    var iDENTITY_NUMBERParameter = iDENTITY_NUMBER != null ?
        //        new ObjectParameter("IDENTITY_NUMBER", iDENTITY_NUMBER) :
        //        new ObjectParameter("IDENTITY_NUMBER", typeof(string));

        //    var sEXParameter = sEX != null ?
        //        new ObjectParameter("SEX", sEX) :
        //        new ObjectParameter("SEX", typeof(string));

        //    var aDDRESSParameter = aDDRESS != null ?
        //        new ObjectParameter("ADDRESS", aDDRESS) :
        //        new ObjectParameter("ADDRESS", typeof(string));

        //    var dESCRIPTIONParameter = dESCRIPTION != null ?
        //        new ObjectParameter("DESCRIPTION", dESCRIPTION) :
        //        new ObjectParameter("DESCRIPTION", typeof(string));

        //    var iMAGEParameter = iMAGE != null ?
        //        new ObjectParameter("IMAGE", iMAGE) :
        //        new ObjectParameter("IMAGE", typeof(byte[]));

        //    var eM_STATUSParameter = eM_STATUS.HasValue ?
        //        new ObjectParameter("EM_STATUS", eM_STATUS) :
        //        new ObjectParameter("EM_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("employees_update", eM_IDParameter, dEP_IDParameter, eM_NAMEParameter, eM_CODEParameter, pHONEParameter, iDENTITY_NUMBERParameter, sEXParameter, aDDRESSParameter, dESCRIPTIONParameter, iMAGEParameter, eM_STATUSParameter);
        //}

        //public virtual ObjectResult<string> GetXMLDemo()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetXMLDemo");
        //}

        //public virtual ObjectResult<string> GetXMLDemo1()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetXMLDemo1");
        //}

        //public virtual ObjectResult<string> GetXMLDemo2()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetXMLDemo2");
        //}

        //public virtual ObjectResult<holiday_Available_Result> holiday_Available()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<holiday_Available_Result>("holiday_Available");
        //}

        //public virtual int holiday_delete(Nullable<int> hOL_ID)
        //{
        //    var hOL_IDParameter = hOL_ID.HasValue ?
        //        new ObjectParameter("HOL_ID", hOL_ID) :
        //        new ObjectParameter("HOL_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("holiday_delete", hOL_IDParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> holiday_findHoliday(string vALUE)
        //{
        //    var vALUEParameter = vALUE != null ?
        //        new ObjectParameter("VALUE", vALUE) :
        //        new ObjectParameter("VALUE", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("holiday_findHoliday", vALUEParameter);
        //}

        //public virtual ObjectResult<holiday_GetAll_Result> holiday_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<holiday_GetAll_Result>("holiday_GetAll");
        //}

        //public virtual ObjectResult<Nullable<int>> holiday_insert(Nullable<int> hOL_ID, string hOL_NAME, string hOL_FROM, string hOL_TO, Nullable<bool> hOL_STATUS)
        //{
        //    var hOL_IDParameter = hOL_ID.HasValue ?
        //        new ObjectParameter("HOL_ID", hOL_ID) :
        //        new ObjectParameter("HOL_ID", typeof(int));

        //    var hOL_NAMEParameter = hOL_NAME != null ?
        //        new ObjectParameter("HOL_NAME", hOL_NAME) :
        //        new ObjectParameter("HOL_NAME", typeof(string));

        //    var hOL_FROMParameter = hOL_FROM != null ?
        //        new ObjectParameter("HOL_FROM", hOL_FROM) :
        //        new ObjectParameter("HOL_FROM", typeof(string));

        //    var hOL_TOParameter = hOL_TO != null ?
        //        new ObjectParameter("HOL_TO", hOL_TO) :
        //        new ObjectParameter("HOL_TO", typeof(string));

        //    var hOL_STATUSParameter = hOL_STATUS.HasValue ?
        //        new ObjectParameter("HOL_STATUS", hOL_STATUS) :
        //        new ObjectParameter("HOL_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("holiday_insert", hOL_IDParameter, hOL_NAMEParameter, hOL_FROMParameter, hOL_TOParameter, hOL_STATUSParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> holiday_IsExist(string hOL_NAME)
        //{
        //    var hOL_NAMEParameter = hOL_NAME != null ?
        //        new ObjectParameter("HOL_NAME", hOL_NAME) :
        //        new ObjectParameter("HOL_NAME", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("holiday_IsExist", hOL_NAMEParameter);
        //}

        //public virtual int holiday_update(Nullable<int> hOL_ID, string hOL_NAME, string hOL_FROM, string hOL_TO, Nullable<bool> hOL_STATUS)
        //{
        //    var hOL_IDParameter = hOL_ID.HasValue ?
        //        new ObjectParameter("HOL_ID", hOL_ID) :
        //        new ObjectParameter("HOL_ID", typeof(int));

        //    var hOL_NAMEParameter = hOL_NAME != null ?
        //        new ObjectParameter("HOL_NAME", hOL_NAME) :
        //        new ObjectParameter("HOL_NAME", typeof(string));

        //    var hOL_FROMParameter = hOL_FROM != null ?
        //        new ObjectParameter("HOL_FROM", hOL_FROM) :
        //        new ObjectParameter("HOL_FROM", typeof(string));

        //    var hOL_TOParameter = hOL_TO != null ?
        //        new ObjectParameter("HOL_TO", hOL_TO) :
        //        new ObjectParameter("HOL_TO", typeof(string));

        //    var hOL_STATUSParameter = hOL_STATUS.HasValue ?
        //        new ObjectParameter("HOL_STATUS", hOL_STATUS) :
        //        new ObjectParameter("HOL_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("holiday_update", hOL_IDParameter, hOL_NAMEParameter, hOL_FROMParameter, hOL_TOParameter, hOL_STATUSParameter);
        //}

        //public virtual ObjectResult<paging_barcodes_Result> paging_barcodes(Nullable<int> pageNumber, Nullable<int> pageSize)
        //{
        //    var pageNumberParameter = pageNumber.HasValue ?
        //        new ObjectParameter("PageNumber", pageNumber) :
        //        new ObjectParameter("PageNumber", typeof(int));

        //    var pageSizeParameter = pageSize.HasValue ?
        //        new ObjectParameter("PageSize", pageSize) :
        //        new ObjectParameter("PageSize", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paging_barcodes_Result>("paging_barcodes", pageNumberParameter, pageSizeParameter);
        //}

        //public virtual ObjectResult<paging_detail_sales_Result> paging_detail_sales(Nullable<int> pageNumber, Nullable<int> pageSize)
        //{
        //    var pageNumberParameter = pageNumber.HasValue ?
        //        new ObjectParameter("PageNumber", pageNumber) :
        //        new ObjectParameter("PageNumber", typeof(int));

        //    var pageSizeParameter = pageSize.HasValue ?
        //        new ObjectParameter("PageSize", pageSize) :
        //        new ObjectParameter("PageSize", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paging_detail_sales_Result>("paging_detail_sales", pageNumberParameter, pageSizeParameter);
        //}

        //public virtual ObjectResult<paging_io_info_Result> paging_io_info(Nullable<int> pageNumber, Nullable<int> pageSize)
        //{
        //    var pageNumberParameter = pageNumber.HasValue ?
        //        new ObjectParameter("PageNumber", pageNumber) :
        //        new ObjectParameter("PageNumber", typeof(int));

        //    var pageSizeParameter = pageSize.HasValue ?
        //        new ObjectParameter("PageSize", pageSize) :
        //        new ObjectParameter("PageSize", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paging_io_info_Result>("paging_io_info", pageNumberParameter, pageSizeParameter);
        //}

        //public virtual int paging_sale_no(Nullable<int> pageNumber, Nullable<int> pageSize)
        //{
        //    var pageNumberParameter = pageNumber.HasValue ?
        //        new ObjectParameter("PageNumber", pageNumber) :
        //        new ObjectParameter("PageNumber", typeof(int));

        //    var pageSizeParameter = pageSize.HasValue ?
        //        new ObjectParameter("PageSize", pageSize) :
        //        new ObjectParameter("PageSize", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paging_sale_no", pageNumberParameter, pageSizeParameter);
        //}

        //public virtual int priviles_Delete(Nullable<int> pRI_ID)
        //{
        //    var pRI_IDParameter = pRI_ID.HasValue ?
        //        new ObjectParameter("PRI_ID", pRI_ID) :
        //        new ObjectParameter("PRI_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("priviles_Delete", pRI_IDParameter);
        //}

        //public virtual ObjectResult<priviles_GetAll_Result> priviles_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<priviles_GetAll_Result>("priviles_GetAll");
        //}

        //public virtual ObjectResult<priviles_GetAll_Visible_Result> priviles_GetAll_Visible()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<priviles_GetAll_Visible_Result>("priviles_GetAll_Visible");
        //}

        //public virtual ObjectResult<Nullable<int>> priviles_insert(Nullable<int> pRI_ID, string pRI_DESCRIPTION, Nullable<bool> pRI_STATUS)
        //{
        //    var pRI_IDParameter = pRI_ID.HasValue ?
        //        new ObjectParameter("PRI_ID", pRI_ID) :
        //        new ObjectParameter("PRI_ID", typeof(int));

        //    var pRI_DESCRIPTIONParameter = pRI_DESCRIPTION != null ?
        //        new ObjectParameter("PRI_DESCRIPTION", pRI_DESCRIPTION) :
        //        new ObjectParameter("PRI_DESCRIPTION", typeof(string));

        //    var pRI_STATUSParameter = pRI_STATUS.HasValue ?
        //        new ObjectParameter("PRI_STATUS", pRI_STATUS) :
        //        new ObjectParameter("PRI_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("priviles_insert", pRI_IDParameter, pRI_DESCRIPTIONParameter, pRI_STATUSParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> priviles_IsExists(Nullable<int> pRI_ID, string pRI_DESCRIPTION)
        //{
        //    var pRI_IDParameter = pRI_ID.HasValue ?
        //        new ObjectParameter("PRI_ID", pRI_ID) :
        //        new ObjectParameter("PRI_ID", typeof(int));

        //    var pRI_DESCRIPTIONParameter = pRI_DESCRIPTION != null ?
        //        new ObjectParameter("PRI_DESCRIPTION", pRI_DESCRIPTION) :
        //        new ObjectParameter("PRI_DESCRIPTION", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("priviles_IsExists", pRI_IDParameter, pRI_DESCRIPTIONParameter);
        //}

        //public virtual int priviles_update(Nullable<int> pRI_ID, string pRI_DESCRIPTION, Nullable<bool> pRI_STATUS)
        //{
        //    var pRI_IDParameter = pRI_ID.HasValue ?
        //        new ObjectParameter("PRI_ID", pRI_ID) :
        //        new ObjectParameter("PRI_ID", typeof(int));

        //    var pRI_DESCRIPTIONParameter = pRI_DESCRIPTION != null ?
        //        new ObjectParameter("PRI_DESCRIPTION", pRI_DESCRIPTION) :
        //        new ObjectParameter("PRI_DESCRIPTION", typeof(string));

        //    var pRI_STATUSParameter = pRI_STATUS.HasValue ?
        //        new ObjectParameter("PRI_STATUS", pRI_STATUS) :
        //        new ObjectParameter("PRI_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("priviles_update", pRI_IDParameter, pRI_DESCRIPTIONParameter, pRI_STATUSParameter);
        //}

        //public virtual int redeem_add_formula_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("redeem_add_formula_GetAll");
        //}

        //public virtual int redeem_formula_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("redeem_formula_GetAll");
        //}

        //public virtual ObjectResult<Nullable<int>> redeem_transform_get(Nullable<int> id)
        //{
        //    var idParameter = id.HasValue ?
        //        new ObjectParameter("id", id) :
        //        new ObjectParameter("id", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("redeem_transform_get", idParameter);
        //}

        //public virtual int redeem_transform_update(Nullable<int> id, Nullable<int> value)
        //{
        //    var idParameter = id.HasValue ?
        //        new ObjectParameter("id", id) :
        //        new ObjectParameter("id", typeof(int));

        //    var valueParameter = value.HasValue ?
        //        new ObjectParameter("value", value) :
        //        new ObjectParameter("value", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("redeem_transform_update", idParameter, valueParameter);
        //}

        //public virtual ObjectResult<select_account_Result> select_account(Nullable<int> aCC_ID)
        //{
        //    var aCC_IDParameter = aCC_ID.HasValue ?
        //        new ObjectParameter("ACC_ID", aCC_ID) :
        //        new ObjectParameter("ACC_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<select_account_Result>("select_account", aCC_IDParameter);
        //}

        //public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        //{
        //    var diagramnameParameter = diagramname != null ?
        //        new ObjectParameter("diagramname", diagramname) :
        //        new ObjectParameter("diagramname", typeof(string));

        //    var owner_idParameter = owner_id.HasValue ?
        //        new ObjectParameter("owner_id", owner_id) :
        //        new ObjectParameter("owner_id", typeof(int));

        //    var versionParameter = version.HasValue ?
        //        new ObjectParameter("version", version) :
        //        new ObjectParameter("version", typeof(int));

        //    var definitionParameter = definition != null ?
        //        new ObjectParameter("definition", definition) :
        //        new ObjectParameter("definition", typeof(byte[]));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        //}

        //public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        //{
        //    var diagramnameParameter = diagramname != null ?
        //        new ObjectParameter("diagramname", diagramname) :
        //        new ObjectParameter("diagramname", typeof(string));

        //    var owner_idParameter = owner_id.HasValue ?
        //        new ObjectParameter("owner_id", owner_id) :
        //        new ObjectParameter("owner_id", typeof(int));

        //    var versionParameter = version.HasValue ?
        //        new ObjectParameter("version", version) :
        //        new ObjectParameter("version", typeof(int));

        //    var definitionParameter = definition != null ?
        //        new ObjectParameter("definition", definition) :
        //        new ObjectParameter("definition", typeof(byte[]));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        //}

        //public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        //{
        //    var diagramnameParameter = diagramname != null ?
        //        new ObjectParameter("diagramname", diagramname) :
        //        new ObjectParameter("diagramname", typeof(string));

        //    var owner_idParameter = owner_id.HasValue ?
        //        new ObjectParameter("owner_id", owner_id) :
        //        new ObjectParameter("owner_id", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        //}

        //public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        //{
        //    var diagramnameParameter = diagramname != null ?
        //        new ObjectParameter("diagramname", diagramname) :
        //        new ObjectParameter("diagramname", typeof(string));

        //    var owner_idParameter = owner_id.HasValue ?
        //        new ObjectParameter("owner_id", owner_id) :
        //        new ObjectParameter("owner_id", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        //}

        //public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        //{
        //    var diagramnameParameter = diagramname != null ?
        //        new ObjectParameter("diagramname", diagramname) :
        //        new ObjectParameter("diagramname", typeof(string));

        //    var owner_idParameter = owner_id.HasValue ?
        //        new ObjectParameter("owner_id", owner_id) :
        //        new ObjectParameter("owner_id", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        //}

        //public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        //{
        //    var diagramnameParameter = diagramname != null ?
        //        new ObjectParameter("diagramname", diagramname) :
        //        new ObjectParameter("diagramname", typeof(string));

        //    var owner_idParameter = owner_id.HasValue ?
        //        new ObjectParameter("owner_id", owner_id) :
        //        new ObjectParameter("owner_id", typeof(int));

        //    var new_diagramnameParameter = new_diagramname != null ?
        //        new ObjectParameter("new_diagramname", new_diagramname) :
        //        new ObjectParameter("new_diagramname", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        //}

        //public virtual int sp_upgraddiagrams()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        //}

        //public virtual ObjectResult<statistic_barcode_Result> statistic_barcode(Nullable<int> number)
        //{
        //    var numberParameter = number.HasValue ?
        //        new ObjectParameter("number", number) :
        //        new ObjectParameter("number", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_barcode_Result>("statistic_barcode", numberParameter);
        //}

        //public virtual ObjectResult<statistic_department_Result> statistic_department()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_department_Result>("statistic_department");
        //}

        //public virtual ObjectResult<statistic_device_all_Result> statistic_device_all()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_device_all_Result>("statistic_device_all");
        //}

        //public virtual ObjectResult<statistic_DoanhThuTheoKhuVuc_Result> statistic_DoanhThuTheoKhuVuc(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_DoanhThuTheoKhuVuc_Result>("statistic_DoanhThuTheoKhuVuc", sTART_DATEParameter, eND_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_DoanhThuTheoLoaiVe_Result> statistic_DoanhThuTheoLoaiVe(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_DoanhThuTheoLoaiVe_Result>("statistic_DoanhThuTheoLoaiVe", sTART_DATEParameter, eND_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_DoanhThuTheoNhanVien_Result> statistic_DoanhThuTheoNhanVien(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_DoanhThuTheoNhanVien_Result>("statistic_DoanhThuTheoNhanVien", sTART_DATEParameter, eND_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_DoanhThuTheoNhanVien1_Result> statistic_DoanhThuTheoNhanVien1(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_DoanhThuTheoNhanVien1_Result>("statistic_DoanhThuTheoNhanVien1", sTART_DATEParameter, eND_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_DoanhThuTheoThoiGian_Result> statistic_DoanhThuTheoThoiGian(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_DoanhThuTheoThoiGian_Result>("statistic_DoanhThuTheoThoiGian", sTART_DATEParameter, eND_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_employee_Result> statistic_employee(Nullable<bool> sTATUS)
        //{
        //    var sTATUSParameter = sTATUS.HasValue ?
        //        new ObjectParameter("STATUS", sTATUS) :
        //        new ObjectParameter("STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_employee_Result>("statistic_employee", sTATUSParameter);
        //}

        //public virtual ObjectResult<statistic_employees_Result> statistic_employees()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_employees_Result>("statistic_employees");
        //}

        //public virtual ObjectResult<statistic_ThongKeKhauTru_Result> statistic_ThongKeKhauTru(string from, string to, Nullable<int> iS_WEEKEND, Nullable<int> iS_HOLIDAY, string strSQL)
        //{
        //    var fromParameter = from != null ?
        //        new ObjectParameter("From", from) :
        //        new ObjectParameter("From", typeof(string));

        //    var toParameter = to != null ?
        //        new ObjectParameter("To", to) :
        //        new ObjectParameter("To", typeof(string));

        //    var iS_WEEKENDParameter = iS_WEEKEND.HasValue ?
        //        new ObjectParameter("IS_WEEKEND", iS_WEEKEND) :
        //        new ObjectParameter("IS_WEEKEND", typeof(int));

        //    var iS_HOLIDAYParameter = iS_HOLIDAY.HasValue ?
        //        new ObjectParameter("IS_HOLIDAY", iS_HOLIDAY) :
        //        new ObjectParameter("IS_HOLIDAY", typeof(int));

        //    var strSQLParameter = strSQL != null ?
        //        new ObjectParameter("strSQL", strSQL) :
        //        new ObjectParameter("strSQL", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_ThongKeKhauTru_Result>("statistic_ThongKeKhauTru", fromParameter, toParameter, iS_WEEKENDParameter, iS_HOLIDAYParameter, strSQLParameter);
        //}

        //public virtual ObjectResult<statistic_ticket_damage_Result> statistic_ticket_damage(Nullable<System.DateTime> eND_APPLY_DATE)
        //{
        //    var eND_APPLY_DATEParameter = eND_APPLY_DATE.HasValue ?
        //        new ObjectParameter("END_APPLY_DATE", eND_APPLY_DATE) :
        //        new ObjectParameter("END_APPLY_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_ticket_damage_Result>("statistic_ticket_damage", eND_APPLY_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_ticket_not_active_Result> statistic_ticket_not_active(Nullable<System.DateTime> sTART_APPLY_DATE, Nullable<System.DateTime> eND_APPLY_DATE)
        //{
        //    var sTART_APPLY_DATEParameter = sTART_APPLY_DATE.HasValue ?
        //        new ObjectParameter("START_APPLY_DATE", sTART_APPLY_DATE) :
        //        new ObjectParameter("START_APPLY_DATE", typeof(System.DateTime));

        //    var eND_APPLY_DATEParameter = eND_APPLY_DATE.HasValue ?
        //        new ObjectParameter("END_APPLY_DATE", eND_APPLY_DATE) :
        //        new ObjectParameter("END_APPLY_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_ticket_not_active_Result>("statistic_ticket_not_active", sTART_APPLY_DATEParameter, eND_APPLY_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_ticket_printed_Result> statistic_ticket_printed(string tYPE_CODE, string zONE_CODE, string eM_CODE, Nullable<System.DateTime> sTART_CREATE_DATE, Nullable<System.DateTime> eND_CREATE_DATE, Nullable<System.DateTime> sTART_APPLY_DATE, Nullable<System.DateTime> eND_APPLY_DATE)
        //{
        //    var tYPE_CODEParameter = tYPE_CODE != null ?
        //        new ObjectParameter("TYPE_CODE", tYPE_CODE) :
        //        new ObjectParameter("TYPE_CODE", typeof(string));

        //    var zONE_CODEParameter = zONE_CODE != null ?
        //        new ObjectParameter("ZONE_CODE", zONE_CODE) :
        //        new ObjectParameter("ZONE_CODE", typeof(string));

        //    var eM_CODEParameter = eM_CODE != null ?
        //        new ObjectParameter("EM_CODE", eM_CODE) :
        //        new ObjectParameter("EM_CODE", typeof(string));

        //    var sTART_CREATE_DATEParameter = sTART_CREATE_DATE.HasValue ?
        //        new ObjectParameter("START_CREATE_DATE", sTART_CREATE_DATE) :
        //        new ObjectParameter("START_CREATE_DATE", typeof(System.DateTime));

        //    var eND_CREATE_DATEParameter = eND_CREATE_DATE.HasValue ?
        //        new ObjectParameter("END_CREATE_DATE", eND_CREATE_DATE) :
        //        new ObjectParameter("END_CREATE_DATE", typeof(System.DateTime));

        //    var sTART_APPLY_DATEParameter = sTART_APPLY_DATE.HasValue ?
        //        new ObjectParameter("START_APPLY_DATE", sTART_APPLY_DATE) :
        //        new ObjectParameter("START_APPLY_DATE", typeof(System.DateTime));

        //    var eND_APPLY_DATEParameter = eND_APPLY_DATE.HasValue ?
        //        new ObjectParameter("END_APPLY_DATE", eND_APPLY_DATE) :
        //        new ObjectParameter("END_APPLY_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_ticket_printed_Result>("statistic_ticket_printed", tYPE_CODEParameter, zONE_CODEParameter, eM_CODEParameter, sTART_CREATE_DATEParameter, eND_CREATE_DATEParameter, sTART_APPLY_DATEParameter, eND_APPLY_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_ticket_sale_Result> statistic_ticket_sale(string tYPE_CODE, string zONE_CODE, string eM_CODE, Nullable<System.DateTime> sTART_CREATE_DATE, Nullable<System.DateTime> eND_CREATE_DATE, Nullable<System.DateTime> sTART_APPLY_DATE, Nullable<System.DateTime> eND_APPLY_DATE)
        //{
        //    var tYPE_CODEParameter = tYPE_CODE != null ?
        //        new ObjectParameter("TYPE_CODE", tYPE_CODE) :
        //        new ObjectParameter("TYPE_CODE", typeof(string));

        //    var zONE_CODEParameter = zONE_CODE != null ?
        //        new ObjectParameter("ZONE_CODE", zONE_CODE) :
        //        new ObjectParameter("ZONE_CODE", typeof(string));

        //    var eM_CODEParameter = eM_CODE != null ?
        //        new ObjectParameter("EM_CODE", eM_CODE) :
        //        new ObjectParameter("EM_CODE", typeof(string));

        //    var sTART_CREATE_DATEParameter = sTART_CREATE_DATE.HasValue ?
        //        new ObjectParameter("START_CREATE_DATE", sTART_CREATE_DATE) :
        //        new ObjectParameter("START_CREATE_DATE", typeof(System.DateTime));

        //    var eND_CREATE_DATEParameter = eND_CREATE_DATE.HasValue ?
        //        new ObjectParameter("END_CREATE_DATE", eND_CREATE_DATE) :
        //        new ObjectParameter("END_CREATE_DATE", typeof(System.DateTime));

        //    var sTART_APPLY_DATEParameter = sTART_APPLY_DATE.HasValue ?
        //        new ObjectParameter("START_APPLY_DATE", sTART_APPLY_DATE) :
        //        new ObjectParameter("START_APPLY_DATE", typeof(System.DateTime));

        //    var eND_APPLY_DATEParameter = eND_APPLY_DATE.HasValue ?
        //        new ObjectParameter("END_APPLY_DATE", eND_APPLY_DATE) :
        //        new ObjectParameter("END_APPLY_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_ticket_sale_Result>("statistic_ticket_sale", tYPE_CODEParameter, zONE_CODEParameter, eM_CODEParameter, sTART_CREATE_DATEParameter, eND_CREATE_DATEParameter, sTART_APPLY_DATEParameter, eND_APPLY_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_ticket_sale2_Result> statistic_ticket_sale2(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_ticket_sale2_Result>("statistic_ticket_sale2", sTART_DATEParameter, eND_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_ticket_sale3_Result> statistic_ticket_sale3(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE, Nullable<int> eM_ID, Nullable<int> zONE_ID)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    var eM_IDParameter = eM_ID.HasValue ?
        //        new ObjectParameter("EM_ID", eM_ID) :
        //        new ObjectParameter("EM_ID", typeof(int));

        //    var zONE_IDParameter = zONE_ID.HasValue ?
        //        new ObjectParameter("ZONE_ID", zONE_ID) :
        //        new ObjectParameter("ZONE_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_ticket_sale3_Result>("statistic_ticket_sale3", sTART_DATEParameter, eND_DATEParameter, eM_IDParameter, zONE_IDParameter);
        //}

        //public virtual ObjectResult<statistic_ticketByType_Result> statistic_ticketByType(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_ticketByType_Result>("statistic_ticketByType", sTART_DATEParameter, eND_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_ticketTotalSold_Result> statistic_ticketTotalSold(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_ticketTotalSold_Result>("statistic_ticketTotalSold", sTART_DATEParameter, eND_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_ticketUsedFree_Result> statistic_ticketUsedFree(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_ticketUsedFree_Result>("statistic_ticketUsedFree", sTART_DATEParameter, eND_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_user_info_Result> statistic_user_info()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_user_info_Result>("statistic_user_info");
        //}

        //public virtual ObjectResult<statistic_VeKhachDangKy_Result> statistic_VeKhachDangKy(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_VeKhachDangKy_Result>("statistic_VeKhachDangKy", sTART_DATEParameter, eND_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_VeKhachVangLai_Result> statistic_VeKhachVangLai(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_VeKhachVangLai_Result>("statistic_VeKhachVangLai", sTART_DATEParameter, eND_DATEParameter);
        //}

        //public virtual ObjectResult<Nullable<long>> ticket_price_FindPricebyHol(Nullable<int> tYPEID, Nullable<int> zONE_ID, Nullable<int> tF_ID, Nullable<int> hOL_ID)
        //{
        //    var tYPEIDParameter = tYPEID.HasValue ?
        //        new ObjectParameter("TYPEID", tYPEID) :
        //        new ObjectParameter("TYPEID", typeof(int));

        //    var zONE_IDParameter = zONE_ID.HasValue ?
        //        new ObjectParameter("ZONE_ID", zONE_ID) :
        //        new ObjectParameter("ZONE_ID", typeof(int));

        //    var tF_IDParameter = tF_ID.HasValue ?
        //        new ObjectParameter("TF_ID", tF_ID) :
        //        new ObjectParameter("TF_ID", typeof(int));

        //    var hOL_IDParameter = hOL_ID.HasValue ?
        //        new ObjectParameter("HOL_ID", hOL_ID) :
        //        new ObjectParameter("HOL_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("ticket_price_FindPricebyHol", tYPEIDParameter, zONE_IDParameter, tF_IDParameter, hOL_IDParameter);
        //}

        //public virtual ObjectResult<Nullable<long>> ticket_price_FindPricebyIsWeekend(Nullable<int> tYPEID, Nullable<int> zONE_ID, Nullable<int> tF_ID, Nullable<bool> wD_ISWEEKEND)
        //{
        //    var tYPEIDParameter = tYPEID.HasValue ?
        //        new ObjectParameter("TYPEID", tYPEID) :
        //        new ObjectParameter("TYPEID", typeof(int));

        //    var zONE_IDParameter = zONE_ID.HasValue ?
        //        new ObjectParameter("ZONE_ID", zONE_ID) :
        //        new ObjectParameter("ZONE_ID", typeof(int));

        //    var tF_IDParameter = tF_ID.HasValue ?
        //        new ObjectParameter("TF_ID", tF_ID) :
        //        new ObjectParameter("TF_ID", typeof(int));

        //    var wD_ISWEEKENDParameter = wD_ISWEEKEND.HasValue ?
        //        new ObjectParameter("WD_ISWEEKEND", wD_ISWEEKEND) :
        //        new ObjectParameter("WD_ISWEEKEND", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("ticket_price_FindPricebyIsWeekend", tYPEIDParameter, zONE_IDParameter, tF_IDParameter, wD_ISWEEKENDParameter);
        //}

        //public virtual ObjectResult<ticket_price_GetAll_Result> ticket_price_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ticket_price_GetAll_Result>("ticket_price_GetAll");
        //}

        //public virtual ObjectResult<Nullable<int>> ticket_price_insert(Nullable<int> pRICE_ID, Nullable<int> cT_ID, Nullable<int> tYPEID, Nullable<int> zONE_ID, Nullable<int> tF_ID, Nullable<int> hOL_ID, Nullable<bool> wD_ISWEEKEND, Nullable<long> pRICE, string tEXT_PRICE, Nullable<int> aCC_ID)
        //{
        //    var pRICE_IDParameter = pRICE_ID.HasValue ?
        //        new ObjectParameter("PRICE_ID", pRICE_ID) :
        //        new ObjectParameter("PRICE_ID", typeof(int));

        //    var cT_IDParameter = cT_ID.HasValue ?
        //        new ObjectParameter("CT_ID", cT_ID) :
        //        new ObjectParameter("CT_ID", typeof(int));

        //    var tYPEIDParameter = tYPEID.HasValue ?
        //        new ObjectParameter("TYPEID", tYPEID) :
        //        new ObjectParameter("TYPEID", typeof(int));

        //    var zONE_IDParameter = zONE_ID.HasValue ?
        //        new ObjectParameter("ZONE_ID", zONE_ID) :
        //        new ObjectParameter("ZONE_ID", typeof(int));

        //    var tF_IDParameter = tF_ID.HasValue ?
        //        new ObjectParameter("TF_ID", tF_ID) :
        //        new ObjectParameter("TF_ID", typeof(int));

        //    var hOL_IDParameter = hOL_ID.HasValue ?
        //        new ObjectParameter("HOL_ID", hOL_ID) :
        //        new ObjectParameter("HOL_ID", typeof(int));

        //    var wD_ISWEEKENDParameter = wD_ISWEEKEND.HasValue ?
        //        new ObjectParameter("WD_ISWEEKEND", wD_ISWEEKEND) :
        //        new ObjectParameter("WD_ISWEEKEND", typeof(bool));

        //    var pRICEParameter = pRICE.HasValue ?
        //        new ObjectParameter("PRICE", pRICE) :
        //        new ObjectParameter("PRICE", typeof(long));

        //    var tEXT_PRICEParameter = tEXT_PRICE != null ?
        //        new ObjectParameter("TEXT_PRICE", tEXT_PRICE) :
        //        new ObjectParameter("TEXT_PRICE", typeof(string));

        //    var aCC_IDParameter = aCC_ID.HasValue ?
        //        new ObjectParameter("ACC_ID", aCC_ID) :
        //        new ObjectParameter("ACC_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ticket_price_insert", pRICE_IDParameter, cT_IDParameter, tYPEIDParameter, zONE_IDParameter, tF_IDParameter, hOL_IDParameter, wD_ISWEEKENDParameter, pRICEParameter, tEXT_PRICEParameter, aCC_IDParameter);
        //}

        //public virtual ObjectResult<ticket_price_IsExistPrice_Result> ticket_price_IsExistPrice(Nullable<int> tYPEID, Nullable<int> zONE_ID, Nullable<int> tF_ID, Nullable<int> hOL_ID, Nullable<bool> wD_ISWEEKEND)
        //{
        //    var tYPEIDParameter = tYPEID.HasValue ?
        //        new ObjectParameter("TYPEID", tYPEID) :
        //        new ObjectParameter("TYPEID", typeof(int));

        //    var zONE_IDParameter = zONE_ID.HasValue ?
        //        new ObjectParameter("ZONE_ID", zONE_ID) :
        //        new ObjectParameter("ZONE_ID", typeof(int));

        //    var tF_IDParameter = tF_ID.HasValue ?
        //        new ObjectParameter("TF_ID", tF_ID) :
        //        new ObjectParameter("TF_ID", typeof(int));

        //    var hOL_IDParameter = hOL_ID.HasValue ?
        //        new ObjectParameter("HOL_ID", hOL_ID) :
        //        new ObjectParameter("HOL_ID", typeof(int));

        //    var wD_ISWEEKENDParameter = wD_ISWEEKEND.HasValue ?
        //        new ObjectParameter("WD_ISWEEKEND", wD_ISWEEKEND) :
        //        new ObjectParameter("WD_ISWEEKEND", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ticket_price_IsExistPrice_Result>("ticket_price_IsExistPrice", tYPEIDParameter, zONE_IDParameter, tF_IDParameter, hOL_IDParameter, wD_ISWEEKENDParameter);
        //}

        //public virtual int ticket_price_update(Nullable<int> pRICE_ID, Nullable<int> cT_ID, Nullable<int> tYPEID, Nullable<int> zONE_ID, Nullable<int> tF_ID, Nullable<int> hOL_ID, Nullable<bool> wD_ISWEEKEND, Nullable<long> pRICE, string tEXT_PRICE, Nullable<int> aCC_ID)
        //{
        //    var pRICE_IDParameter = pRICE_ID.HasValue ?
        //        new ObjectParameter("PRICE_ID", pRICE_ID) :
        //        new ObjectParameter("PRICE_ID", typeof(int));

        //    var cT_IDParameter = cT_ID.HasValue ?
        //        new ObjectParameter("CT_ID", cT_ID) :
        //        new ObjectParameter("CT_ID", typeof(int));

        //    var tYPEIDParameter = tYPEID.HasValue ?
        //        new ObjectParameter("TYPEID", tYPEID) :
        //        new ObjectParameter("TYPEID", typeof(int));

        //    var zONE_IDParameter = zONE_ID.HasValue ?
        //        new ObjectParameter("ZONE_ID", zONE_ID) :
        //        new ObjectParameter("ZONE_ID", typeof(int));

        //    var tF_IDParameter = tF_ID.HasValue ?
        //        new ObjectParameter("TF_ID", tF_ID) :
        //        new ObjectParameter("TF_ID", typeof(int));

        //    var hOL_IDParameter = hOL_ID.HasValue ?
        //        new ObjectParameter("HOL_ID", hOL_ID) :
        //        new ObjectParameter("HOL_ID", typeof(int));

        //    var wD_ISWEEKENDParameter = wD_ISWEEKEND.HasValue ?
        //        new ObjectParameter("WD_ISWEEKEND", wD_ISWEEKEND) :
        //        new ObjectParameter("WD_ISWEEKEND", typeof(bool));

        //    var pRICEParameter = pRICE.HasValue ?
        //        new ObjectParameter("PRICE", pRICE) :
        //        new ObjectParameter("PRICE", typeof(long));

        //    var tEXT_PRICEParameter = tEXT_PRICE != null ?
        //        new ObjectParameter("TEXT_PRICE", tEXT_PRICE) :
        //        new ObjectParameter("TEXT_PRICE", typeof(string));

        //    var aCC_IDParameter = aCC_ID.HasValue ?
        //        new ObjectParameter("ACC_ID", aCC_ID) :
        //        new ObjectParameter("ACC_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ticket_price_update", pRICE_IDParameter, cT_IDParameter, tYPEIDParameter, zONE_IDParameter, tF_IDParameter, hOL_IDParameter, wD_ISWEEKENDParameter, pRICEParameter, tEXT_PRICEParameter, aCC_IDParameter);
        //}

        //public virtual ObjectResult<ticket_sale_Child2_Result> ticket_sale_Child2(string from, string to)
        //{
        //    var fromParameter = from != null ?
        //        new ObjectParameter("From", from) :
        //        new ObjectParameter("From", typeof(string));

        //    var toParameter = to != null ?
        //        new ObjectParameter("To", to) :
        //        new ObjectParameter("To", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ticket_sale_Child2_Result>("ticket_sale_Child2", fromParameter, toParameter);
        //}

        //public virtual ObjectResult<ticket_sale_ChildTop5000Desc_Result> ticket_sale_ChildTop5000Desc()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ticket_sale_ChildTop5000Desc_Result>("ticket_sale_ChildTop5000Desc");
        //}

        //public virtual int ticket_sale_delete(Nullable<long> tS_ID)
        //{
        //    var tS_IDParameter = tS_ID.HasValue ?
        //        new ObjectParameter("TS_ID", tS_ID) :
        //        new ObjectParameter("TS_ID", typeof(long));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ticket_sale_delete", tS_IDParameter);
        //}

        //public virtual ObjectResult<ticket_sale_getAll_Result> ticket_sale_getAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ticket_sale_getAll_Result>("ticket_sale_getAll");
        //}

        //public virtual ObjectResult<Nullable<long>> ticket_sale_insert(Nullable<long> tS_ID, string tS_NO, Nullable<long> pRICE, Nullable<long> pAY, Nullable<int> dISC_ID, string dESCRIPTION, Nullable<int> uSER_ID, Nullable<int> dISCOUNT_MONEY, Nullable<int> rEDEEM_ADD, Nullable<int> rEDEEM_SUB, Nullable<int> rEDEEM_SUB_MONEY, Nullable<int> aCC_ID)
        //{
        //    var tS_IDParameter = tS_ID.HasValue ?
        //        new ObjectParameter("TS_ID", tS_ID) :
        //        new ObjectParameter("TS_ID", typeof(long));

        //    var tS_NOParameter = tS_NO != null ?
        //        new ObjectParameter("TS_NO", tS_NO) :
        //        new ObjectParameter("TS_NO", typeof(string));

        //    var pRICEParameter = pRICE.HasValue ?
        //        new ObjectParameter("PRICE", pRICE) :
        //        new ObjectParameter("PRICE", typeof(long));

        //    var pAYParameter = pAY.HasValue ?
        //        new ObjectParameter("PAY", pAY) :
        //        new ObjectParameter("PAY", typeof(long));

        //    var dISC_IDParameter = dISC_ID.HasValue ?
        //        new ObjectParameter("DISC_ID", dISC_ID) :
        //        new ObjectParameter("DISC_ID", typeof(int));

        //    var dESCRIPTIONParameter = dESCRIPTION != null ?
        //        new ObjectParameter("DESCRIPTION", dESCRIPTION) :
        //        new ObjectParameter("DESCRIPTION", typeof(string));

        //    var uSER_IDParameter = uSER_ID.HasValue ?
        //        new ObjectParameter("USER_ID", uSER_ID) :
        //        new ObjectParameter("USER_ID", typeof(int));

        //    var dISCOUNT_MONEYParameter = dISCOUNT_MONEY.HasValue ?
        //        new ObjectParameter("DISCOUNT_MONEY", dISCOUNT_MONEY) :
        //        new ObjectParameter("DISCOUNT_MONEY", typeof(int));

        //    var rEDEEM_ADDParameter = rEDEEM_ADD.HasValue ?
        //        new ObjectParameter("REDEEM_ADD", rEDEEM_ADD) :
        //        new ObjectParameter("REDEEM_ADD", typeof(int));

        //    var rEDEEM_SUBParameter = rEDEEM_SUB.HasValue ?
        //        new ObjectParameter("REDEEM_SUB", rEDEEM_SUB) :
        //        new ObjectParameter("REDEEM_SUB", typeof(int));

        //    var rEDEEM_SUB_MONEYParameter = rEDEEM_SUB_MONEY.HasValue ?
        //        new ObjectParameter("REDEEM_SUB_MONEY", rEDEEM_SUB_MONEY) :
        //        new ObjectParameter("REDEEM_SUB_MONEY", typeof(int));

        //    var aCC_IDParameter = aCC_ID.HasValue ?
        //        new ObjectParameter("ACC_ID", aCC_ID) :
        //        new ObjectParameter("ACC_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("ticket_sale_insert", tS_IDParameter, tS_NOParameter, pRICEParameter, pAYParameter, dISC_IDParameter, dESCRIPTIONParameter, uSER_IDParameter, dISCOUNT_MONEYParameter, rEDEEM_ADDParameter, rEDEEM_SUBParameter, rEDEEM_SUB_MONEYParameter, aCC_IDParameter);
        //}

        //public virtual ObjectResult<ticket_sale_Parent_Result> ticket_sale_Parent(Nullable<System.DateTime> from, Nullable<System.DateTime> to, string tS_NO, string dISC_CODE, string eM_CODE, string uSER_CODE)
        //{
        //    var fromParameter = from.HasValue ?
        //        new ObjectParameter("From", from) :
        //        new ObjectParameter("From", typeof(System.DateTime));

        //    var toParameter = to.HasValue ?
        //        new ObjectParameter("To", to) :
        //        new ObjectParameter("To", typeof(System.DateTime));

        //    var tS_NOParameter = tS_NO != null ?
        //        new ObjectParameter("TS_NO", tS_NO) :
        //        new ObjectParameter("TS_NO", typeof(string));

        //    var dISC_CODEParameter = dISC_CODE != null ?
        //        new ObjectParameter("DISC_CODE", dISC_CODE) :
        //        new ObjectParameter("DISC_CODE", typeof(string));

        //    var eM_CODEParameter = eM_CODE != null ?
        //        new ObjectParameter("EM_CODE", eM_CODE) :
        //        new ObjectParameter("EM_CODE", typeof(string));

        //    var uSER_CODEParameter = uSER_CODE != null ?
        //        new ObjectParameter("USER_CODE", uSER_CODE) :
        //        new ObjectParameter("USER_CODE", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ticket_sale_Parent_Result>("ticket_sale_Parent", fromParameter, toParameter, tS_NOParameter, dISC_CODEParameter, eM_CODEParameter, uSER_CODEParameter);
        //}

        //public virtual int ticket_sale_Parent2(Nullable<int> dISC_ID, string tS_NO, Nullable<int> eM_ID, Nullable<int> uSER_ID, string from, string to, string strSQL)
        //{
        //    var dISC_IDParameter = dISC_ID.HasValue ?
        //        new ObjectParameter("DISC_ID", dISC_ID) :
        //        new ObjectParameter("DISC_ID", typeof(int));

        //    var tS_NOParameter = tS_NO != null ?
        //        new ObjectParameter("TS_NO", tS_NO) :
        //        new ObjectParameter("TS_NO", typeof(string));

        //    var eM_IDParameter = eM_ID.HasValue ?
        //        new ObjectParameter("EM_ID", eM_ID) :
        //        new ObjectParameter("EM_ID", typeof(int));

        //    var uSER_IDParameter = uSER_ID.HasValue ?
        //        new ObjectParameter("USER_ID", uSER_ID) :
        //        new ObjectParameter("USER_ID", typeof(int));

        //    var fromParameter = from != null ?
        //        new ObjectParameter("From", from) :
        //        new ObjectParameter("From", typeof(string));

        //    var toParameter = to != null ?
        //        new ObjectParameter("To", to) :
        //        new ObjectParameter("To", typeof(string));

        //    var strSQLParameter = strSQL != null ?
        //        new ObjectParameter("strSQL", strSQL) :
        //        new ObjectParameter("strSQL", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ticket_sale_Parent2", dISC_IDParameter, tS_NOParameter, eM_IDParameter, uSER_IDParameter, fromParameter, toParameter, strSQLParameter);
        //}

        //public virtual ObjectResult<ticket_sale_ParentTop5000Desc_Result> ticket_sale_ParentTop5000Desc()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ticket_sale_ParentTop5000Desc_Result>("ticket_sale_ParentTop5000Desc");
        //}

        //public virtual int ticket_sale_update(Nullable<long> tS_ID, string tS_NO, Nullable<long> pRICE, Nullable<long> pAY, Nullable<int> dISC_ID, string dESCRIPTION, Nullable<int> uSER_ID, Nullable<int> rEDEEM_ADD, Nullable<int> rEDEEM_SUB, Nullable<int> rEDEEM_SUB_MONEY)
        //{
        //    var tS_IDParameter = tS_ID.HasValue ?
        //        new ObjectParameter("TS_ID", tS_ID) :
        //        new ObjectParameter("TS_ID", typeof(long));

        //    var tS_NOParameter = tS_NO != null ?
        //        new ObjectParameter("TS_NO", tS_NO) :
        //        new ObjectParameter("TS_NO", typeof(string));

        //    var pRICEParameter = pRICE.HasValue ?
        //        new ObjectParameter("PRICE", pRICE) :
        //        new ObjectParameter("PRICE", typeof(long));

        //    var pAYParameter = pAY.HasValue ?
        //        new ObjectParameter("PAY", pAY) :
        //        new ObjectParameter("PAY", typeof(long));

        //    var dISC_IDParameter = dISC_ID.HasValue ?
        //        new ObjectParameter("DISC_ID", dISC_ID) :
        //        new ObjectParameter("DISC_ID", typeof(int));

        //    var dESCRIPTIONParameter = dESCRIPTION != null ?
        //        new ObjectParameter("DESCRIPTION", dESCRIPTION) :
        //        new ObjectParameter("DESCRIPTION", typeof(string));

        //    var uSER_IDParameter = uSER_ID.HasValue ?
        //        new ObjectParameter("USER_ID", uSER_ID) :
        //        new ObjectParameter("USER_ID", typeof(int));

        //    var rEDEEM_ADDParameter = rEDEEM_ADD.HasValue ?
        //        new ObjectParameter("REDEEM_ADD", rEDEEM_ADD) :
        //        new ObjectParameter("REDEEM_ADD", typeof(int));

        //    var rEDEEM_SUBParameter = rEDEEM_SUB.HasValue ?
        //        new ObjectParameter("REDEEM_SUB", rEDEEM_SUB) :
        //        new ObjectParameter("REDEEM_SUB", typeof(int));

        //    var rEDEEM_SUB_MONEYParameter = rEDEEM_SUB_MONEY.HasValue ?
        //        new ObjectParameter("REDEEM_SUB_MONEY", rEDEEM_SUB_MONEY) :
        //        new ObjectParameter("REDEEM_SUB_MONEY", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ticket_sale_update", tS_IDParameter, tS_NOParameter, pRICEParameter, pAYParameter, dISC_IDParameter, dESCRIPTIONParameter, uSER_IDParameter, rEDEEM_ADDParameter, rEDEEM_SUBParameter, rEDEEM_SUB_MONEYParameter);
        //}

        //public virtual int ticket_type_Delete(Nullable<int> tYPEID)
        //{
        //    var tYPEIDParameter = tYPEID.HasValue ?
        //        new ObjectParameter("TYPEID", tYPEID) :
        //        new ObjectParameter("TYPEID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ticket_type_Delete", tYPEIDParameter);
        //}

        //public virtual ObjectResult<ticket_type_GetAll_Result> ticket_type_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ticket_type_GetAll_Result>("ticket_type_GetAll");
        //}

        //public virtual ObjectResult<string> ticket_type_GetTypeNamebyId(Nullable<int> tYPEID)
        //{
        //    var tYPEIDParameter = tYPEID.HasValue ?
        //        new ObjectParameter("TYPEID", tYPEID) :
        //        new ObjectParameter("TYPEID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("ticket_type_GetTypeNamebyId", tYPEIDParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> ticket_type_insert(Nullable<int> tYPEID, string tYPENAME, string tYPE_CODE, Nullable<int> tYPE_CHECK, string dESCRIPTIONS)
        //{
        //    var tYPEIDParameter = tYPEID.HasValue ?
        //        new ObjectParameter("TYPEID", tYPEID) :
        //        new ObjectParameter("TYPEID", typeof(int));

        //    var tYPENAMEParameter = tYPENAME != null ?
        //        new ObjectParameter("TYPENAME", tYPENAME) :
        //        new ObjectParameter("TYPENAME", typeof(string));

        //    var tYPE_CODEParameter = tYPE_CODE != null ?
        //        new ObjectParameter("TYPE_CODE", tYPE_CODE) :
        //        new ObjectParameter("TYPE_CODE", typeof(string));

        //    var tYPE_CHECKParameter = tYPE_CHECK.HasValue ?
        //        new ObjectParameter("TYPE_CHECK", tYPE_CHECK) :
        //        new ObjectParameter("TYPE_CHECK", typeof(int));

        //    var dESCRIPTIONSParameter = dESCRIPTIONS != null ?
        //        new ObjectParameter("DESCRIPTIONS", dESCRIPTIONS) :
        //        new ObjectParameter("DESCRIPTIONS", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ticket_type_insert", tYPEIDParameter, tYPENAMEParameter, tYPE_CODEParameter, tYPE_CHECKParameter, dESCRIPTIONSParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> ticket_type_IsExistTYPE_CODE(Nullable<int> tYPEID, string tYPE_CODE)
        //{
        //    var tYPEIDParameter = tYPEID.HasValue ?
        //        new ObjectParameter("TYPEID", tYPEID) :
        //        new ObjectParameter("TYPEID", typeof(int));

        //    var tYPE_CODEParameter = tYPE_CODE != null ?
        //        new ObjectParameter("TYPE_CODE", tYPE_CODE) :
        //        new ObjectParameter("TYPE_CODE", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ticket_type_IsExistTYPE_CODE", tYPEIDParameter, tYPE_CODEParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> ticket_type_IsExistTYPENAME(Nullable<int> tYPEID, string tYPENAME)
        //{
        //    var tYPEIDParameter = tYPEID.HasValue ?
        //        new ObjectParameter("TYPEID", tYPEID) :
        //        new ObjectParameter("TYPEID", typeof(int));

        //    var tYPENAMEParameter = tYPENAME != null ?
        //        new ObjectParameter("TYPENAME", tYPENAME) :
        //        new ObjectParameter("TYPENAME", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ticket_type_IsExistTYPENAME", tYPEIDParameter, tYPENAMEParameter);
        //}

        //public virtual int ticket_type_update(Nullable<int> tYPEID, string tYPENAME, string tYPE_CODE, Nullable<int> tYPE_CHECK, string dESCRIPTIONS)
        //{
        //    var tYPEIDParameter = tYPEID.HasValue ?
        //        new ObjectParameter("TYPEID", tYPEID) :
        //        new ObjectParameter("TYPEID", typeof(int));

        //    var tYPENAMEParameter = tYPENAME != null ?
        //        new ObjectParameter("TYPENAME", tYPENAME) :
        //        new ObjectParameter("TYPENAME", typeof(string));

        //    var tYPE_CODEParameter = tYPE_CODE != null ?
        //        new ObjectParameter("TYPE_CODE", tYPE_CODE) :
        //        new ObjectParameter("TYPE_CODE", typeof(string));

        //    var tYPE_CHECKParameter = tYPE_CHECK.HasValue ?
        //        new ObjectParameter("TYPE_CHECK", tYPE_CHECK) :
        //        new ObjectParameter("TYPE_CHECK", typeof(int));

        //    var dESCRIPTIONSParameter = dESCRIPTIONS != null ?
        //        new ObjectParameter("DESCRIPTIONS", dESCRIPTIONS) :
        //        new ObjectParameter("DESCRIPTIONS", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ticket_type_update", tYPEIDParameter, tYPENAMEParameter, tYPE_CODEParameter, tYPE_CHECKParameter, dESCRIPTIONSParameter);
        //}

        //public virtual int time_frame_delete(Nullable<int> tF_ID)
        //{
        //    var tF_IDParameter = tF_ID.HasValue ?
        //        new ObjectParameter("TF_ID", tF_ID) :
        //        new ObjectParameter("TF_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("time_frame_delete", tF_IDParameter);
        //}

        //public virtual ObjectResult<time_frame_GetAll_Result> time_frame_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<time_frame_GetAll_Result>("time_frame_GetAll");
        //}

        //public virtual ObjectResult<Nullable<int>> time_frame_GetIdByCheck(Nullable<int> tF_CHECK)
        //{
        //    var tF_CHECKParameter = tF_CHECK.HasValue ?
        //        new ObjectParameter("TF_CHECK", tF_CHECK) :
        //        new ObjectParameter("TF_CHECK", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("time_frame_GetIdByCheck", tF_CHECKParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> time_frame_GetIDbyLifeTime()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("time_frame_GetIDbyLifeTime");
        //}

        //public virtual ObjectResult<time_frame_GetNotAllDay_Result> time_frame_GetNotAllDay()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<time_frame_GetNotAllDay_Result>("time_frame_GetNotAllDay");
        //}

        //public virtual ObjectResult<time_frame_GetRowById_Result> time_frame_GetRowById(Nullable<int> tF_ID)
        //{
        //    var tF_IDParameter = tF_ID.HasValue ?
        //        new ObjectParameter("TF_ID", tF_ID) :
        //        new ObjectParameter("TF_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<time_frame_GetRowById_Result>("time_frame_GetRowById", tF_IDParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> time_frame_insert(Nullable<int> tF_ID, string tF_NAME, Nullable<int> tF_CHECK, Nullable<System.TimeSpan> tF_FROM, Nullable<System.TimeSpan> tF_TO, string tF_DES, Nullable<bool> tF_STATUS)
        //{
        //    var tF_IDParameter = tF_ID.HasValue ?
        //        new ObjectParameter("TF_ID", tF_ID) :
        //        new ObjectParameter("TF_ID", typeof(int));

        //    var tF_NAMEParameter = tF_NAME != null ?
        //        new ObjectParameter("TF_NAME", tF_NAME) :
        //        new ObjectParameter("TF_NAME", typeof(string));

        //    var tF_CHECKParameter = tF_CHECK.HasValue ?
        //        new ObjectParameter("TF_CHECK", tF_CHECK) :
        //        new ObjectParameter("TF_CHECK", typeof(int));

        //    var tF_FROMParameter = tF_FROM.HasValue ?
        //        new ObjectParameter("TF_FROM", tF_FROM) :
        //        new ObjectParameter("TF_FROM", typeof(System.TimeSpan));

        //    var tF_TOParameter = tF_TO.HasValue ?
        //        new ObjectParameter("TF_TO", tF_TO) :
        //        new ObjectParameter("TF_TO", typeof(System.TimeSpan));

        //    var tF_DESParameter = tF_DES != null ?
        //        new ObjectParameter("TF_DES", tF_DES) :
        //        new ObjectParameter("TF_DES", typeof(string));

        //    var tF_STATUSParameter = tF_STATUS.HasValue ?
        //        new ObjectParameter("TF_STATUS", tF_STATUS) :
        //        new ObjectParameter("TF_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("time_frame_insert", tF_IDParameter, tF_NAMEParameter, tF_CHECKParameter, tF_FROMParameter, tF_TOParameter, tF_DESParameter, tF_STATUSParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> time_frame_IsExist(string tF_NAME)
        //{
        //    var tF_NAMEParameter = tF_NAME != null ?
        //        new ObjectParameter("TF_NAME", tF_NAME) :
        //        new ObjectParameter("TF_NAME", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("time_frame_IsExist", tF_NAMEParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> time_frame_IsExistInDAY(string vALUE)
        //{
        //    var vALUEParameter = vALUE != null ?
        //        new ObjectParameter("VALUE", vALUE) :
        //        new ObjectParameter("VALUE", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("time_frame_IsExistInDAY", vALUEParameter);
        //}

        //public virtual ObjectResult<string> time_frame_kiemTraTrungKhungGio(Nullable<int> tF_ID, Nullable<System.TimeSpan> tF_TO, Nullable<System.TimeSpan> tF_FROM)
        //{
        //    var tF_IDParameter = tF_ID.HasValue ?
        //        new ObjectParameter("TF_ID", tF_ID) :
        //        new ObjectParameter("TF_ID", typeof(int));

        //    var tF_TOParameter = tF_TO.HasValue ?
        //        new ObjectParameter("TF_TO", tF_TO) :
        //        new ObjectParameter("TF_TO", typeof(System.TimeSpan));

        //    var tF_FROMParameter = tF_FROM.HasValue ?
        //        new ObjectParameter("TF_FROM", tF_FROM) :
        //        new ObjectParameter("TF_FROM", typeof(System.TimeSpan));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("time_frame_kiemTraTrungKhungGio", tF_IDParameter, tF_TOParameter, tF_FROMParameter);
        //}

        //public virtual int time_frame_update(Nullable<int> tF_ID, string tF_NAME, Nullable<int> tF_CHECK, Nullable<System.TimeSpan> tF_FROM, Nullable<System.TimeSpan> tF_TO, string tF_DES, Nullable<bool> tF_STATUS)
        //{
        //    var tF_IDParameter = tF_ID.HasValue ?
        //        new ObjectParameter("TF_ID", tF_ID) :
        //        new ObjectParameter("TF_ID", typeof(int));

        //    var tF_NAMEParameter = tF_NAME != null ?
        //        new ObjectParameter("TF_NAME", tF_NAME) :
        //        new ObjectParameter("TF_NAME", typeof(string));

        //    var tF_CHECKParameter = tF_CHECK.HasValue ?
        //        new ObjectParameter("TF_CHECK", tF_CHECK) :
        //        new ObjectParameter("TF_CHECK", typeof(int));

        //    var tF_FROMParameter = tF_FROM.HasValue ?
        //        new ObjectParameter("TF_FROM", tF_FROM) :
        //        new ObjectParameter("TF_FROM", typeof(System.TimeSpan));

        //    var tF_TOParameter = tF_TO.HasValue ?
        //        new ObjectParameter("TF_TO", tF_TO) :
        //        new ObjectParameter("TF_TO", typeof(System.TimeSpan));

        //    var tF_DESParameter = tF_DES != null ?
        //        new ObjectParameter("TF_DES", tF_DES) :
        //        new ObjectParameter("TF_DES", typeof(string));

        //    var tF_STATUSParameter = tF_STATUS.HasValue ?
        //        new ObjectParameter("TF_STATUS", tF_STATUS) :
        //        new ObjectParameter("TF_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("time_frame_update", tF_IDParameter, tF_NAMEParameter, tF_CHECKParameter, tF_FROMParameter, tF_TOParameter, tF_DESParameter, tF_STATUSParameter);
        //}

        //public virtual int update_cardno(Nullable<int> cA_ID, Nullable<int> uSER_ID, string cA_NO, string cA_NUMBER, Nullable<int> cT_ID, Nullable<int> tYPEID, Nullable<bool> cA_STATUS, Nullable<bool> cA_ACTIVE, string dESCRIPTION, Nullable<System.DateTime> aPPLY_DATE, Nullable<System.DateTime> eXPRIED_DATE, Nullable<bool> cA_DAMAGED, Nullable<bool> cA_LOST, Nullable<bool> uSING, Nullable<bool> aLLOW_SYNCHRONIZED, string zONE_LIST, Nullable<int> aCC_ID)
        //{
        //    var cA_IDParameter = cA_ID.HasValue ?
        //        new ObjectParameter("CA_ID", cA_ID) :
        //        new ObjectParameter("CA_ID", typeof(int));

        //    var uSER_IDParameter = uSER_ID.HasValue ?
        //        new ObjectParameter("USER_ID", uSER_ID) :
        //        new ObjectParameter("USER_ID", typeof(int));

        //    var cA_NOParameter = cA_NO != null ?
        //        new ObjectParameter("CA_NO", cA_NO) :
        //        new ObjectParameter("CA_NO", typeof(string));

        //    var cA_NUMBERParameter = cA_NUMBER != null ?
        //        new ObjectParameter("CA_NUMBER", cA_NUMBER) :
        //        new ObjectParameter("CA_NUMBER", typeof(string));

        //    var cT_IDParameter = cT_ID.HasValue ?
        //        new ObjectParameter("CT_ID", cT_ID) :
        //        new ObjectParameter("CT_ID", typeof(int));

        //    var tYPEIDParameter = tYPEID.HasValue ?
        //        new ObjectParameter("TYPEID", tYPEID) :
        //        new ObjectParameter("TYPEID", typeof(int));

        //    var cA_STATUSParameter = cA_STATUS.HasValue ?
        //        new ObjectParameter("CA_STATUS", cA_STATUS) :
        //        new ObjectParameter("CA_STATUS", typeof(bool));

        //    var cA_ACTIVEParameter = cA_ACTIVE.HasValue ?
        //        new ObjectParameter("CA_ACTIVE", cA_ACTIVE) :
        //        new ObjectParameter("CA_ACTIVE", typeof(bool));

        //    var dESCRIPTIONParameter = dESCRIPTION != null ?
        //        new ObjectParameter("DESCRIPTION", dESCRIPTION) :
        //        new ObjectParameter("DESCRIPTION", typeof(string));

        //    var aPPLY_DATEParameter = aPPLY_DATE.HasValue ?
        //        new ObjectParameter("APPLY_DATE", aPPLY_DATE) :
        //        new ObjectParameter("APPLY_DATE", typeof(System.DateTime));

        //    var eXPRIED_DATEParameter = eXPRIED_DATE.HasValue ?
        //        new ObjectParameter("EXPRIED_DATE", eXPRIED_DATE) :
        //        new ObjectParameter("EXPRIED_DATE", typeof(System.DateTime));

        //    var cA_DAMAGEDParameter = cA_DAMAGED.HasValue ?
        //        new ObjectParameter("CA_DAMAGED", cA_DAMAGED) :
        //        new ObjectParameter("CA_DAMAGED", typeof(bool));

        //    var cA_LOSTParameter = cA_LOST.HasValue ?
        //        new ObjectParameter("CA_LOST", cA_LOST) :
        //        new ObjectParameter("CA_LOST", typeof(bool));

        //    var uSINGParameter = uSING.HasValue ?
        //        new ObjectParameter("USING", uSING) :
        //        new ObjectParameter("USING", typeof(bool));

        //    var aLLOW_SYNCHRONIZEDParameter = aLLOW_SYNCHRONIZED.HasValue ?
        //        new ObjectParameter("ALLOW_SYNCHRONIZED", aLLOW_SYNCHRONIZED) :
        //        new ObjectParameter("ALLOW_SYNCHRONIZED", typeof(bool));

        //    var zONE_LISTParameter = zONE_LIST != null ?
        //        new ObjectParameter("ZONE_LIST", zONE_LIST) :
        //        new ObjectParameter("ZONE_LIST", typeof(string));

        //    var aCC_IDParameter = aCC_ID.HasValue ?
        //        new ObjectParameter("ACC_ID", aCC_ID) :
        //        new ObjectParameter("ACC_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_cardno", cA_IDParameter, uSER_IDParameter, cA_NOParameter, cA_NUMBERParameter, cT_IDParameter, tYPEIDParameter, cA_STATUSParameter, cA_ACTIVEParameter, dESCRIPTIONParameter, aPPLY_DATEParameter, eXPRIED_DATEParameter, cA_DAMAGEDParameter, cA_LOSTParameter, uSINGParameter, aLLOW_SYNCHRONIZEDParameter, zONE_LISTParameter, aCC_IDParameter);
        //}

        //public virtual int update_cardtype(Nullable<int> cT_ID, string cT_NAME, string cT_CODE, string cT_DESCRIPTION, Nullable<bool> cT_STATUS)
        //{
        //    var cT_IDParameter = cT_ID.HasValue ?
        //        new ObjectParameter("CT_ID", cT_ID) :
        //        new ObjectParameter("CT_ID", typeof(int));

        //    var cT_NAMEParameter = cT_NAME != null ?
        //        new ObjectParameter("CT_NAME", cT_NAME) :
        //        new ObjectParameter("CT_NAME", typeof(string));

        //    var cT_CODEParameter = cT_CODE != null ?
        //        new ObjectParameter("CT_CODE", cT_CODE) :
        //        new ObjectParameter("CT_CODE", typeof(string));

        //    var cT_DESCRIPTIONParameter = cT_DESCRIPTION != null ?
        //        new ObjectParameter("CT_DESCRIPTION", cT_DESCRIPTION) :
        //        new ObjectParameter("CT_DESCRIPTION", typeof(string));

        //    var cT_STATUSParameter = cT_STATUS.HasValue ?
        //        new ObjectParameter("CT_STATUS", cT_STATUS) :
        //        new ObjectParameter("CT_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_cardtype", cT_IDParameter, cT_NAMEParameter, cT_CODEParameter, cT_DESCRIPTIONParameter, cT_STATUSParameter);
        //}

        //public virtual int update_device(Nullable<int> dEVICE_ID, string dEVICE_NAME, string dEVICE_CODE, Nullable<int> dT_ID, Nullable<int> cONTROLLER_ID, string dEVICE_MAC, Nullable<int> dEVICE_PORT, string dEVICE_DES, Nullable<bool> dEVICE_STATUS)
        //{
        //    var dEVICE_IDParameter = dEVICE_ID.HasValue ?
        //        new ObjectParameter("DEVICE_ID", dEVICE_ID) :
        //        new ObjectParameter("DEVICE_ID", typeof(int));

        //    var dEVICE_NAMEParameter = dEVICE_NAME != null ?
        //        new ObjectParameter("DEVICE_NAME", dEVICE_NAME) :
        //        new ObjectParameter("DEVICE_NAME", typeof(string));

        //    var dEVICE_CODEParameter = dEVICE_CODE != null ?
        //        new ObjectParameter("DEVICE_CODE", dEVICE_CODE) :
        //        new ObjectParameter("DEVICE_CODE", typeof(string));

        //    var dT_IDParameter = dT_ID.HasValue ?
        //        new ObjectParameter("DT_ID", dT_ID) :
        //        new ObjectParameter("DT_ID", typeof(int));

        //    var cONTROLLER_IDParameter = cONTROLLER_ID.HasValue ?
        //        new ObjectParameter("CONTROLLER_ID", cONTROLLER_ID) :
        //        new ObjectParameter("CONTROLLER_ID", typeof(int));

        //    var dEVICE_MACParameter = dEVICE_MAC != null ?
        //        new ObjectParameter("DEVICE_MAC", dEVICE_MAC) :
        //        new ObjectParameter("DEVICE_MAC", typeof(string));

        //    var dEVICE_PORTParameter = dEVICE_PORT.HasValue ?
        //        new ObjectParameter("DEVICE_PORT", dEVICE_PORT) :
        //        new ObjectParameter("DEVICE_PORT", typeof(int));

        //    var dEVICE_DESParameter = dEVICE_DES != null ?
        //        new ObjectParameter("DEVICE_DES", dEVICE_DES) :
        //        new ObjectParameter("DEVICE_DES", typeof(string));

        //    var dEVICE_STATUSParameter = dEVICE_STATUS.HasValue ?
        //        new ObjectParameter("DEVICE_STATUS", dEVICE_STATUS) :
        //        new ObjectParameter("DEVICE_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_device", dEVICE_IDParameter, dEVICE_NAMEParameter, dEVICE_CODEParameter, dT_IDParameter, cONTROLLER_IDParameter, dEVICE_MACParameter, dEVICE_PORTParameter, dEVICE_DESParameter, dEVICE_STATUSParameter);
        //}

        //public virtual int update_game_sport(Nullable<int> gS_ID, string gS_NAME, Nullable<int> gS_LIMIT, string gS_DES, Nullable<bool> gS_STATUS)
        //{
        //    var gS_IDParameter = gS_ID.HasValue ?
        //        new ObjectParameter("GS_ID", gS_ID) :
        //        new ObjectParameter("GS_ID", typeof(int));

        //    var gS_NAMEParameter = gS_NAME != null ?
        //        new ObjectParameter("GS_NAME", gS_NAME) :
        //        new ObjectParameter("GS_NAME", typeof(string));

        //    var gS_LIMITParameter = gS_LIMIT.HasValue ?
        //        new ObjectParameter("GS_LIMIT", gS_LIMIT) :
        //        new ObjectParameter("GS_LIMIT", typeof(int));

        //    var gS_DESParameter = gS_DES != null ?
        //        new ObjectParameter("GS_DES", gS_DES) :
        //        new ObjectParameter("GS_DES", typeof(string));

        //    var gS_STATUSParameter = gS_STATUS.HasValue ?
        //        new ObjectParameter("GS_STATUS", gS_STATUS) :
        //        new ObjectParameter("GS_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_game_sport", gS_IDParameter, gS_NAMEParameter, gS_LIMITParameter, gS_DESParameter, gS_STATUSParameter);
        //}

        //public virtual int update_io_info(Nullable<long> iO_ID, Nullable<System.DateTime> iO_TIME, Nullable<int> cONTROLLER_ID, Nullable<int> cA_ID, Nullable<long> bAR_ID, Nullable<int> tFA_ID)
        //{
        //    var iO_IDParameter = iO_ID.HasValue ?
        //        new ObjectParameter("IO_ID", iO_ID) :
        //        new ObjectParameter("IO_ID", typeof(long));

        //    var iO_TIMEParameter = iO_TIME.HasValue ?
        //        new ObjectParameter("IO_TIME", iO_TIME) :
        //        new ObjectParameter("IO_TIME", typeof(System.DateTime));

        //    var cONTROLLER_IDParameter = cONTROLLER_ID.HasValue ?
        //        new ObjectParameter("CONTROLLER_ID", cONTROLLER_ID) :
        //        new ObjectParameter("CONTROLLER_ID", typeof(int));

        //    var cA_IDParameter = cA_ID.HasValue ?
        //        new ObjectParameter("CA_ID", cA_ID) :
        //        new ObjectParameter("CA_ID", typeof(int));

        //    var bAR_IDParameter = bAR_ID.HasValue ?
        //        new ObjectParameter("BAR_ID", bAR_ID) :
        //        new ObjectParameter("BAR_ID", typeof(long));

        //    var tFA_IDParameter = tFA_ID.HasValue ?
        //        new ObjectParameter("TFA_ID", tFA_ID) :
        //        new ObjectParameter("TFA_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_io_info", iO_IDParameter, iO_TIMEParameter, cONTROLLER_IDParameter, cA_IDParameter, bAR_IDParameter, tFA_IDParameter);
        //}

        //public virtual int update_menulist(Nullable<int> mNU_ID, string mNU_NAME, string mNU_DISPLAY, string mNU_PARENT)
        //{
        //    var mNU_IDParameter = mNU_ID.HasValue ?
        //        new ObjectParameter("MNU_ID", mNU_ID) :
        //        new ObjectParameter("MNU_ID", typeof(int));

        //    var mNU_NAMEParameter = mNU_NAME != null ?
        //        new ObjectParameter("MNU_NAME", mNU_NAME) :
        //        new ObjectParameter("MNU_NAME", typeof(string));

        //    var mNU_DISPLAYParameter = mNU_DISPLAY != null ?
        //        new ObjectParameter("MNU_DISPLAY", mNU_DISPLAY) :
        //        new ObjectParameter("MNU_DISPLAY", typeof(string));

        //    var mNU_PARENTParameter = mNU_PARENT != null ?
        //        new ObjectParameter("MNU_PARENT", mNU_PARENT) :
        //        new ObjectParameter("MNU_PARENT", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_menulist", mNU_IDParameter, mNU_NAMEParameter, mNU_DISPLAYParameter, mNU_PARENTParameter);
        //}

        //public virtual int update_redeem(Nullable<long> rEDEEM_ID, Nullable<long> sN_ID, Nullable<int> rEDEEM_VALUE, Nullable<int> rEDEEM_MONEY, Nullable<bool> rEDEEM_STATUS)
        //{
        //    var rEDEEM_IDParameter = rEDEEM_ID.HasValue ?
        //        new ObjectParameter("REDEEM_ID", rEDEEM_ID) :
        //        new ObjectParameter("REDEEM_ID", typeof(long));

        //    var sN_IDParameter = sN_ID.HasValue ?
        //        new ObjectParameter("SN_ID", sN_ID) :
        //        new ObjectParameter("SN_ID", typeof(long));

        //    var rEDEEM_VALUEParameter = rEDEEM_VALUE.HasValue ?
        //        new ObjectParameter("REDEEM_VALUE", rEDEEM_VALUE) :
        //        new ObjectParameter("REDEEM_VALUE", typeof(int));

        //    var rEDEEM_MONEYParameter = rEDEEM_MONEY.HasValue ?
        //        new ObjectParameter("REDEEM_MONEY", rEDEEM_MONEY) :
        //        new ObjectParameter("REDEEM_MONEY", typeof(int));

        //    var rEDEEM_STATUSParameter = rEDEEM_STATUS.HasValue ?
        //        new ObjectParameter("REDEEM_STATUS", rEDEEM_STATUS) :
        //        new ObjectParameter("REDEEM_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_redeem", rEDEEM_IDParameter, sN_IDParameter, rEDEEM_VALUEParameter, rEDEEM_MONEYParameter, rEDEEM_STATUSParameter);
        //}

        //public virtual int update_redeem_add_formula(Nullable<int> rAF_ID, string rAF_NAME, Nullable<int> rAF_MONEY, Nullable<int> rAF_VALUE, Nullable<bool> rAF_ACTIVE, Nullable<System.DateTime> rAF_UPDATE_DATE, Nullable<int> aCC_ID)
        //{
        //    var rAF_IDParameter = rAF_ID.HasValue ?
        //        new ObjectParameter("RAF_ID", rAF_ID) :
        //        new ObjectParameter("RAF_ID", typeof(int));

        //    var rAF_NAMEParameter = rAF_NAME != null ?
        //        new ObjectParameter("RAF_NAME", rAF_NAME) :
        //        new ObjectParameter("RAF_NAME", typeof(string));

        //    var rAF_MONEYParameter = rAF_MONEY.HasValue ?
        //        new ObjectParameter("RAF_MONEY", rAF_MONEY) :
        //        new ObjectParameter("RAF_MONEY", typeof(int));

        //    var rAF_VALUEParameter = rAF_VALUE.HasValue ?
        //        new ObjectParameter("RAF_VALUE", rAF_VALUE) :
        //        new ObjectParameter("RAF_VALUE", typeof(int));

        //    var rAF_ACTIVEParameter = rAF_ACTIVE.HasValue ?
        //        new ObjectParameter("RAF_ACTIVE", rAF_ACTIVE) :
        //        new ObjectParameter("RAF_ACTIVE", typeof(bool));

        //    var rAF_UPDATE_DATEParameter = rAF_UPDATE_DATE.HasValue ?
        //        new ObjectParameter("RAF_UPDATE_DATE", rAF_UPDATE_DATE) :
        //        new ObjectParameter("RAF_UPDATE_DATE", typeof(System.DateTime));

        //    var aCC_IDParameter = aCC_ID.HasValue ?
        //        new ObjectParameter("ACC_ID", aCC_ID) :
        //        new ObjectParameter("ACC_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_redeem_add_formula", rAF_IDParameter, rAF_NAMEParameter, rAF_MONEYParameter, rAF_VALUEParameter, rAF_ACTIVEParameter, rAF_UPDATE_DATEParameter, aCC_IDParameter);
        //}

        //public virtual int update_redeem_formula(Nullable<int> rF_ID, string rF_NAME, Nullable<int> rF_REDVALUE, Nullable<int> rF_MONEY, Nullable<bool> rF_ACTIVE, Nullable<System.DateTime> rF_UPDATE_DATE, Nullable<int> aCC_ID)
        //{
        //    var rF_IDParameter = rF_ID.HasValue ?
        //        new ObjectParameter("RF_ID", rF_ID) :
        //        new ObjectParameter("RF_ID", typeof(int));

        //    var rF_NAMEParameter = rF_NAME != null ?
        //        new ObjectParameter("RF_NAME", rF_NAME) :
        //        new ObjectParameter("RF_NAME", typeof(string));

        //    var rF_REDVALUEParameter = rF_REDVALUE.HasValue ?
        //        new ObjectParameter("RF_REDVALUE", rF_REDVALUE) :
        //        new ObjectParameter("RF_REDVALUE", typeof(int));

        //    var rF_MONEYParameter = rF_MONEY.HasValue ?
        //        new ObjectParameter("RF_MONEY", rF_MONEY) :
        //        new ObjectParameter("RF_MONEY", typeof(int));

        //    var rF_ACTIVEParameter = rF_ACTIVE.HasValue ?
        //        new ObjectParameter("RF_ACTIVE", rF_ACTIVE) :
        //        new ObjectParameter("RF_ACTIVE", typeof(bool));

        //    var rF_UPDATE_DATEParameter = rF_UPDATE_DATE.HasValue ?
        //        new ObjectParameter("RF_UPDATE_DATE", rF_UPDATE_DATE) :
        //        new ObjectParameter("RF_UPDATE_DATE", typeof(System.DateTime));

        //    var aCC_IDParameter = aCC_ID.HasValue ?
        //        new ObjectParameter("ACC_ID", aCC_ID) :
        //        new ObjectParameter("ACC_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_redeem_formula", rF_IDParameter, rF_NAMEParameter, rF_REDVALUEParameter, rF_MONEYParameter, rF_ACTIVEParameter, rF_UPDATE_DATEParameter, aCC_IDParameter);
        //}

        //public virtual int update_sale_no(Nullable<long> sN_ID, string sN_NO, string dESCRIPTION, Nullable<int> uSER_ID)
        //{
        //    var sN_IDParameter = sN_ID.HasValue ?
        //        new ObjectParameter("SN_ID", sN_ID) :
        //        new ObjectParameter("SN_ID", typeof(long));

        //    var sN_NOParameter = sN_NO != null ?
        //        new ObjectParameter("SN_NO", sN_NO) :
        //        new ObjectParameter("SN_NO", typeof(string));

        //    var dESCRIPTIONParameter = dESCRIPTION != null ?
        //        new ObjectParameter("DESCRIPTION", dESCRIPTION) :
        //        new ObjectParameter("DESCRIPTION", typeof(string));

        //    var uSER_IDParameter = uSER_ID.HasValue ?
        //        new ObjectParameter("USER_ID", uSER_ID) :
        //        new ObjectParameter("USER_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_sale_no", sN_IDParameter, sN_NOParameter, dESCRIPTIONParameter, uSER_IDParameter);
        //}

        //public virtual int update_time_frame_active(Nullable<int> tFA_ID, string tFA_NAME, Nullable<System.TimeSpan> tFA_FROM, Nullable<System.TimeSpan> tFA_TO, string tFA_DES, Nullable<bool> tFA_STATUS)
        //{
        //    var tFA_IDParameter = tFA_ID.HasValue ?
        //        new ObjectParameter("TFA_ID", tFA_ID) :
        //        new ObjectParameter("TFA_ID", typeof(int));

        //    var tFA_NAMEParameter = tFA_NAME != null ?
        //        new ObjectParameter("TFA_NAME", tFA_NAME) :
        //        new ObjectParameter("TFA_NAME", typeof(string));

        //    var tFA_FROMParameter = tFA_FROM.HasValue ?
        //        new ObjectParameter("TFA_FROM", tFA_FROM) :
        //        new ObjectParameter("TFA_FROM", typeof(System.TimeSpan));

        //    var tFA_TOParameter = tFA_TO.HasValue ?
        //        new ObjectParameter("TFA_TO", tFA_TO) :
        //        new ObjectParameter("TFA_TO", typeof(System.TimeSpan));

        //    var tFA_DESParameter = tFA_DES != null ?
        //        new ObjectParameter("TFA_DES", tFA_DES) :
        //        new ObjectParameter("TFA_DES", typeof(string));

        //    var tFA_STATUSParameter = tFA_STATUS.HasValue ?
        //        new ObjectParameter("TFA_STATUS", tFA_STATUS) :
        //        new ObjectParameter("TFA_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_time_frame_active", tFA_IDParameter, tFA_NAMEParameter, tFA_FROMParameter, tFA_TOParameter, tFA_DESParameter, tFA_STATUSParameter);
        //}

        //public virtual int update_unit(Nullable<int> uNIT_ID, string uNIT_CODE, string uNIT_NAME, string uNIT_DES, Nullable<bool> uNIT_STATUS)
        //{
        //    var uNIT_IDParameter = uNIT_ID.HasValue ?
        //        new ObjectParameter("UNIT_ID", uNIT_ID) :
        //        new ObjectParameter("UNIT_ID", typeof(int));

        //    var uNIT_CODEParameter = uNIT_CODE != null ?
        //        new ObjectParameter("UNIT_CODE", uNIT_CODE) :
        //        new ObjectParameter("UNIT_CODE", typeof(string));

        //    var uNIT_NAMEParameter = uNIT_NAME != null ?
        //        new ObjectParameter("UNIT_NAME", uNIT_NAME) :
        //        new ObjectParameter("UNIT_NAME", typeof(string));

        //    var uNIT_DESParameter = uNIT_DES != null ?
        //        new ObjectParameter("UNIT_DES", uNIT_DES) :
        //        new ObjectParameter("UNIT_DES", typeof(string));

        //    var uNIT_STATUSParameter = uNIT_STATUS.HasValue ?
        //        new ObjectParameter("UNIT_STATUS", uNIT_STATUS) :
        //        new ObjectParameter("UNIT_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_unit", uNIT_IDParameter, uNIT_CODEParameter, uNIT_NAMEParameter, uNIT_DESParameter, uNIT_STATUSParameter);
        //}

        //public virtual int update_user_info(Nullable<int> uSER_ID, Nullable<int> uSER_TYPEID, Nullable<int> gS_ID, string uSER_NAME, string uSER_CODE, string pHONE, string iDENTITY_NUMBER, string sEX, Nullable<System.DateTime> uSER_BIRTH, string aDDRESS, byte[] iMAGE, string eMAIL, string nOTE, Nullable<bool> uSER_STATUS, Nullable<int> rEDEEM_POINTS)
        //{
        //    var uSER_IDParameter = uSER_ID.HasValue ?
        //        new ObjectParameter("USER_ID", uSER_ID) :
        //        new ObjectParameter("USER_ID", typeof(int));

        //    var uSER_TYPEIDParameter = uSER_TYPEID.HasValue ?
        //        new ObjectParameter("USER_TYPEID", uSER_TYPEID) :
        //        new ObjectParameter("USER_TYPEID", typeof(int));

        //    var gS_IDParameter = gS_ID.HasValue ?
        //        new ObjectParameter("GS_ID", gS_ID) :
        //        new ObjectParameter("GS_ID", typeof(int));

        //    var uSER_NAMEParameter = uSER_NAME != null ?
        //        new ObjectParameter("USER_NAME", uSER_NAME) :
        //        new ObjectParameter("USER_NAME", typeof(string));

        //    var uSER_CODEParameter = uSER_CODE != null ?
        //        new ObjectParameter("USER_CODE", uSER_CODE) :
        //        new ObjectParameter("USER_CODE", typeof(string));

        //    var pHONEParameter = pHONE != null ?
        //        new ObjectParameter("PHONE", pHONE) :
        //        new ObjectParameter("PHONE", typeof(string));

        //    var iDENTITY_NUMBERParameter = iDENTITY_NUMBER != null ?
        //        new ObjectParameter("IDENTITY_NUMBER", iDENTITY_NUMBER) :
        //        new ObjectParameter("IDENTITY_NUMBER", typeof(string));

        //    var sEXParameter = sEX != null ?
        //        new ObjectParameter("SEX", sEX) :
        //        new ObjectParameter("SEX", typeof(string));

        //    var uSER_BIRTHParameter = uSER_BIRTH.HasValue ?
        //        new ObjectParameter("USER_BIRTH", uSER_BIRTH) :
        //        new ObjectParameter("USER_BIRTH", typeof(System.DateTime));

        //    var aDDRESSParameter = aDDRESS != null ?
        //        new ObjectParameter("ADDRESS", aDDRESS) :
        //        new ObjectParameter("ADDRESS", typeof(string));

        //    var iMAGEParameter = iMAGE != null ?
        //        new ObjectParameter("IMAGE", iMAGE) :
        //        new ObjectParameter("IMAGE", typeof(byte[]));

        //    var eMAILParameter = eMAIL != null ?
        //        new ObjectParameter("EMAIL", eMAIL) :
        //        new ObjectParameter("EMAIL", typeof(string));

        //    var nOTEParameter = nOTE != null ?
        //        new ObjectParameter("NOTE", nOTE) :
        //        new ObjectParameter("NOTE", typeof(string));

        //    var uSER_STATUSParameter = uSER_STATUS.HasValue ?
        //        new ObjectParameter("USER_STATUS", uSER_STATUS) :
        //        new ObjectParameter("USER_STATUS", typeof(bool));

        //    var rEDEEM_POINTSParameter = rEDEEM_POINTS.HasValue ?
        //        new ObjectParameter("REDEEM_POINTS", rEDEEM_POINTS) :
        //        new ObjectParameter("REDEEM_POINTS", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_user_info", uSER_IDParameter, uSER_TYPEIDParameter, gS_IDParameter, uSER_NAMEParameter, uSER_CODEParameter, pHONEParameter, iDENTITY_NUMBERParameter, sEXParameter, uSER_BIRTHParameter, aDDRESSParameter, iMAGEParameter, eMAILParameter, nOTEParameter, uSER_STATUSParameter, rEDEEM_POINTSParameter);
        //}

        //public virtual int update_user_type(Nullable<int> uSER_TYPEID, string uSER_TYPENAME, string dESCRIPTION)
        //{
        //    var uSER_TYPEIDParameter = uSER_TYPEID.HasValue ?
        //        new ObjectParameter("USER_TYPEID", uSER_TYPEID) :
        //        new ObjectParameter("USER_TYPEID", typeof(int));

        //    var uSER_TYPENAMEParameter = uSER_TYPENAME != null ?
        //        new ObjectParameter("USER_TYPENAME", uSER_TYPENAME) :
        //        new ObjectParameter("USER_TYPENAME", typeof(string));

        //    var dESCRIPTIONParameter = dESCRIPTION != null ?
        //        new ObjectParameter("DESCRIPTION", dESCRIPTION) :
        //        new ObjectParameter("DESCRIPTION", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_user_type", uSER_TYPEIDParameter, uSER_TYPENAMEParameter, dESCRIPTIONParameter);
        //}

        //public virtual int update_weekdays(Nullable<int> wD_ID, Nullable<int> wD_CHECK, string wD_NAME)
        //{
        //    var wD_IDParameter = wD_ID.HasValue ?
        //        new ObjectParameter("WD_ID", wD_ID) :
        //        new ObjectParameter("WD_ID", typeof(int));

        //    var wD_CHECKParameter = wD_CHECK.HasValue ?
        //        new ObjectParameter("WD_CHECK", wD_CHECK) :
        //        new ObjectParameter("WD_CHECK", typeof(int));

        //    var wD_NAMEParameter = wD_NAME != null ?
        //        new ObjectParameter("WD_NAME", wD_NAME) :
        //        new ObjectParameter("WD_NAME", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_weekdays", wD_IDParameter, wD_CHECKParameter, wD_NAMEParameter);
        //}

        //public virtual int user_info_UpdatePoint(Nullable<int> uSER_ID, Nullable<int> rEDEEM_POINTS)
        //{
        //    var uSER_IDParameter = uSER_ID.HasValue ?
        //        new ObjectParameter("USER_ID", uSER_ID) :
        //        new ObjectParameter("USER_ID", typeof(int));

        //    var rEDEEM_POINTSParameter = rEDEEM_POINTS.HasValue ?
        //        new ObjectParameter("REDEEM_POINTS", rEDEEM_POINTS) :
        //        new ObjectParameter("REDEEM_POINTS", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("user_info_UpdatePoint", uSER_IDParameter, rEDEEM_POINTSParameter);
        //}

        //public virtual ObjectResult<user_type_GetAll_Result> user_type_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<user_type_GetAll_Result>("user_type_GetAll");
        //}

        //public virtual int userInfo_Delete(Nullable<int> uSER_ID)
        //{
        //    var uSER_IDParameter = uSER_ID.HasValue ?
        //        new ObjectParameter("USER_ID", uSER_ID) :
        //        new ObjectParameter("USER_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("userInfo_Delete", uSER_IDParameter);
        //}

        //public virtual ObjectResult<userInfo_FindInfobyCode_Result> userInfo_FindInfobyCode(string uSER_CODE)
        //{
        //    var uSER_CODEParameter = uSER_CODE != null ?
        //        new ObjectParameter("USER_CODE", uSER_CODE) :
        //        new ObjectParameter("USER_CODE", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<userInfo_FindInfobyCode_Result>("userInfo_FindInfobyCode", uSER_CODEParameter);
        //}

        //public virtual ObjectResult<userInfo_FindInfobyPhone_Result> userInfo_FindInfobyPhone(string pHONE)
        //{
        //    var pHONEParameter = pHONE != null ?
        //        new ObjectParameter("PHONE", pHONE) :
        //        new ObjectParameter("PHONE", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<userInfo_FindInfobyPhone_Result>("userInfo_FindInfobyPhone", pHONEParameter);
        //}

        //public virtual ObjectResult<userInfo_GetAll_Result> userInfo_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<userInfo_GetAll_Result>("userInfo_GetAll");
        //}

        //public virtual ObjectResult<userInfo_GetAllVisible_Result> userInfo_GetAllVisible()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<userInfo_GetAllVisible_Result>("userInfo_GetAllVisible");
        //}

        //public virtual ObjectResult<Nullable<int>> userInfo_insert(Nullable<int> uSER_ID, Nullable<int> uSER_TYPEID, string uSER_NAME, string uSER_CODE, string pHONE, string iDENTITY_NUMBER, string sEX, Nullable<System.DateTime> uSER_BIRTH, string aDDRESS, string eMAIL, byte[] iMAGE, string nOTE, Nullable<bool> uSER_STATUS, Nullable<int> rEDEEM_POINTS, Nullable<System.DateTime> cREATE_DATE, Nullable<System.DateTime> uPDATE_DATE)
        //{
        //    var uSER_IDParameter = uSER_ID.HasValue ?
        //        new ObjectParameter("USER_ID", uSER_ID) :
        //        new ObjectParameter("USER_ID", typeof(int));

        //    var uSER_TYPEIDParameter = uSER_TYPEID.HasValue ?
        //        new ObjectParameter("USER_TYPEID", uSER_TYPEID) :
        //        new ObjectParameter("USER_TYPEID", typeof(int));

        //    var uSER_NAMEParameter = uSER_NAME != null ?
        //        new ObjectParameter("USER_NAME", uSER_NAME) :
        //        new ObjectParameter("USER_NAME", typeof(string));

        //    var uSER_CODEParameter = uSER_CODE != null ?
        //        new ObjectParameter("USER_CODE", uSER_CODE) :
        //        new ObjectParameter("USER_CODE", typeof(string));

        //    var pHONEParameter = pHONE != null ?
        //        new ObjectParameter("PHONE", pHONE) :
        //        new ObjectParameter("PHONE", typeof(string));

        //    var iDENTITY_NUMBERParameter = iDENTITY_NUMBER != null ?
        //        new ObjectParameter("IDENTITY_NUMBER", iDENTITY_NUMBER) :
        //        new ObjectParameter("IDENTITY_NUMBER", typeof(string));

        //    var sEXParameter = sEX != null ?
        //        new ObjectParameter("SEX", sEX) :
        //        new ObjectParameter("SEX", typeof(string));

        //    var uSER_BIRTHParameter = uSER_BIRTH.HasValue ?
        //        new ObjectParameter("USER_BIRTH", uSER_BIRTH) :
        //        new ObjectParameter("USER_BIRTH", typeof(System.DateTime));

        //    var aDDRESSParameter = aDDRESS != null ?
        //        new ObjectParameter("ADDRESS", aDDRESS) :
        //        new ObjectParameter("ADDRESS", typeof(string));

        //    var eMAILParameter = eMAIL != null ?
        //        new ObjectParameter("EMAIL", eMAIL) :
        //        new ObjectParameter("EMAIL", typeof(string));

        //    var iMAGEParameter = iMAGE != null ?
        //        new ObjectParameter("IMAGE", iMAGE) :
        //        new ObjectParameter("IMAGE", typeof(byte[]));

        //    var nOTEParameter = nOTE != null ?
        //        new ObjectParameter("NOTE", nOTE) :
        //        new ObjectParameter("NOTE", typeof(string));

        //    var uSER_STATUSParameter = uSER_STATUS.HasValue ?
        //        new ObjectParameter("USER_STATUS", uSER_STATUS) :
        //        new ObjectParameter("USER_STATUS", typeof(bool));

        //    var rEDEEM_POINTSParameter = rEDEEM_POINTS.HasValue ?
        //        new ObjectParameter("REDEEM_POINTS", rEDEEM_POINTS) :
        //        new ObjectParameter("REDEEM_POINTS", typeof(int));

        //    var cREATE_DATEParameter = cREATE_DATE.HasValue ?
        //        new ObjectParameter("CREATE_DATE", cREATE_DATE) :
        //        new ObjectParameter("CREATE_DATE", typeof(System.DateTime));

        //    var uPDATE_DATEParameter = uPDATE_DATE.HasValue ?
        //        new ObjectParameter("UPDATE_DATE", uPDATE_DATE) :
        //        new ObjectParameter("UPDATE_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("userInfo_insert", uSER_IDParameter, uSER_TYPEIDParameter, uSER_NAMEParameter, uSER_CODEParameter, pHONEParameter, iDENTITY_NUMBERParameter, sEXParameter, uSER_BIRTHParameter, aDDRESSParameter, eMAILParameter, iMAGEParameter, nOTEParameter, uSER_STATUSParameter, rEDEEM_POINTSParameter, cREATE_DATEParameter, uPDATE_DATEParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> userInfo_IsExist(string uSER_CODE)
        //{
        //    var uSER_CODEParameter = uSER_CODE != null ?
        //        new ObjectParameter("USER_CODE", uSER_CODE) :
        //        new ObjectParameter("USER_CODE", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("userInfo_IsExist", uSER_CODEParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> userInfo_IsExistPhone(string nUMBER_PHONE)
        //{
        //    var nUMBER_PHONEParameter = nUMBER_PHONE != null ?
        //        new ObjectParameter("NUMBER_PHONE", nUMBER_PHONE) :
        //        new ObjectParameter("NUMBER_PHONE", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("userInfo_IsExistPhone", nUMBER_PHONEParameter);
        //}

        //public virtual int userInfo_update(Nullable<int> uSER_ID, Nullable<int> uSER_TYPEID, string uSER_NAME, string uSER_CODE, string pHONE, string iDENTITY_NUMBER, string sEX, Nullable<System.DateTime> uSER_BIRTH, string aDDRESS, byte[] iMAGE, string eMAIL, string nOTE, Nullable<bool> uSER_STATUS, Nullable<int> rEDEEM_POINTS, Nullable<System.DateTime> cREATE_DATE, Nullable<System.DateTime> uPDATE_DATE)
        //{
        //    var uSER_IDParameter = uSER_ID.HasValue ?
        //        new ObjectParameter("USER_ID", uSER_ID) :
        //        new ObjectParameter("USER_ID", typeof(int));

        //    var uSER_TYPEIDParameter = uSER_TYPEID.HasValue ?
        //        new ObjectParameter("USER_TYPEID", uSER_TYPEID) :
        //        new ObjectParameter("USER_TYPEID", typeof(int));

        //    var uSER_NAMEParameter = uSER_NAME != null ?
        //        new ObjectParameter("USER_NAME", uSER_NAME) :
        //        new ObjectParameter("USER_NAME", typeof(string));

        //    var uSER_CODEParameter = uSER_CODE != null ?
        //        new ObjectParameter("USER_CODE", uSER_CODE) :
        //        new ObjectParameter("USER_CODE", typeof(string));

        //    var pHONEParameter = pHONE != null ?
        //        new ObjectParameter("PHONE", pHONE) :
        //        new ObjectParameter("PHONE", typeof(string));

        //    var iDENTITY_NUMBERParameter = iDENTITY_NUMBER != null ?
        //        new ObjectParameter("IDENTITY_NUMBER", iDENTITY_NUMBER) :
        //        new ObjectParameter("IDENTITY_NUMBER", typeof(string));

        //    var sEXParameter = sEX != null ?
        //        new ObjectParameter("SEX", sEX) :
        //        new ObjectParameter("SEX", typeof(string));

        //    var uSER_BIRTHParameter = uSER_BIRTH.HasValue ?
        //        new ObjectParameter("USER_BIRTH", uSER_BIRTH) :
        //        new ObjectParameter("USER_BIRTH", typeof(System.DateTime));

        //    var aDDRESSParameter = aDDRESS != null ?
        //        new ObjectParameter("ADDRESS", aDDRESS) :
        //        new ObjectParameter("ADDRESS", typeof(string));

        //    var iMAGEParameter = iMAGE != null ?
        //        new ObjectParameter("IMAGE", iMAGE) :
        //        new ObjectParameter("IMAGE", typeof(byte[]));

        //    var eMAILParameter = eMAIL != null ?
        //        new ObjectParameter("EMAIL", eMAIL) :
        //        new ObjectParameter("EMAIL", typeof(string));

        //    var nOTEParameter = nOTE != null ?
        //        new ObjectParameter("NOTE", nOTE) :
        //        new ObjectParameter("NOTE", typeof(string));

        //    var uSER_STATUSParameter = uSER_STATUS.HasValue ?
        //        new ObjectParameter("USER_STATUS", uSER_STATUS) :
        //        new ObjectParameter("USER_STATUS", typeof(bool));

        //    var rEDEEM_POINTSParameter = rEDEEM_POINTS.HasValue ?
        //        new ObjectParameter("REDEEM_POINTS", rEDEEM_POINTS) :
        //        new ObjectParameter("REDEEM_POINTS", typeof(int));

        //    var cREATE_DATEParameter = cREATE_DATE.HasValue ?
        //        new ObjectParameter("CREATE_DATE", cREATE_DATE) :
        //        new ObjectParameter("CREATE_DATE", typeof(System.DateTime));

        //    var uPDATE_DATEParameter = uPDATE_DATE.HasValue ?
        //        new ObjectParameter("UPDATE_DATE", uPDATE_DATE) :
        //        new ObjectParameter("UPDATE_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("userInfo_update", uSER_IDParameter, uSER_TYPEIDParameter, uSER_NAMEParameter, uSER_CODEParameter, pHONEParameter, iDENTITY_NUMBERParameter, sEXParameter, uSER_BIRTHParameter, aDDRESSParameter, iMAGEParameter, eMAILParameter, nOTEParameter, uSER_STATUSParameter, rEDEEM_POINTSParameter, cREATE_DATEParameter, uPDATE_DATEParameter);
        //}

        //public virtual int userInfo_updateRedeemPoints(Nullable<int> pOINTS, Nullable<int> uSER_ID)
        //{
        //    var pOINTSParameter = pOINTS.HasValue ?
        //        new ObjectParameter("POINTS", pOINTS) :
        //        new ObjectParameter("POINTS", typeof(int));

        //    var uSER_IDParameter = uSER_ID.HasValue ?
        //        new ObjectParameter("USER_ID", uSER_ID) :
        //        new ObjectParameter("USER_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("userInfo_updateRedeemPoints", pOINTSParameter, uSER_IDParameter);
        //}

        //public virtual int visiblecontrols_DeleteByPRI_ID(Nullable<int> pRI_ID)
        //{
        //    var pRI_IDParameter = pRI_ID.HasValue ?
        //        new ObjectParameter("PRI_ID", pRI_ID) :
        //        new ObjectParameter("PRI_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("visiblecontrols_DeleteByPRI_ID", pRI_IDParameter);
        //}

        //public virtual int visiblecontrols_insert(Nullable<int> vI_ID, Nullable<int> pRI_ID, Nullable<int> mNU_ID)
        //{
        //    var vI_IDParameter = vI_ID.HasValue ?
        //        new ObjectParameter("VI_ID", vI_ID) :
        //        new ObjectParameter("VI_ID", typeof(int));

        //    var pRI_IDParameter = pRI_ID.HasValue ?
        //        new ObjectParameter("PRI_ID", pRI_ID) :
        //        new ObjectParameter("PRI_ID", typeof(int));

        //    var mNU_IDParameter = mNU_ID.HasValue ?
        //        new ObjectParameter("MNU_ID", mNU_ID) :
        //        new ObjectParameter("MNU_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("visiblecontrols_insert", vI_IDParameter, pRI_IDParameter, mNU_IDParameter);
        //}

        //public virtual int visiblecontrols_update(Nullable<int> vI_ID, Nullable<int> pRI_ID, Nullable<int> mNU_ID)
        //{
        //    var vI_IDParameter = vI_ID.HasValue ?
        //        new ObjectParameter("VI_ID", vI_ID) :
        //        new ObjectParameter("VI_ID", typeof(int));

        //    var pRI_IDParameter = pRI_ID.HasValue ?
        //        new ObjectParameter("PRI_ID", pRI_ID) :
        //        new ObjectParameter("PRI_ID", typeof(int));

        //    var mNU_IDParameter = mNU_ID.HasValue ?
        //        new ObjectParameter("MNU_ID", mNU_ID) :
        //        new ObjectParameter("MNU_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("visiblecontrols_update", vI_IDParameter, pRI_IDParameter, mNU_IDParameter);
        //}

        //public virtual int weekdays_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("weekdays_GetAll");
        //}

        //public virtual int zone_delete(Nullable<int> zONE_ID)
        //{
        //    var zONE_IDParameter = zONE_ID.HasValue ?
        //        new ObjectParameter("ZONE_ID", zONE_ID) :
        //        new ObjectParameter("ZONE_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("zone_delete", zONE_IDParameter);
        //}

        //public virtual ObjectResult<zone_GetAll_Result> zone_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<zone_GetAll_Result>("zone_GetAll");
        //}

        //public virtual ObjectResult<zone_GetAll_Visible_Result> zone_GetAll_Visible()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<zone_GetAll_Visible_Result>("zone_GetAll_Visible");
        //}

        //public virtual ObjectResult<string> zone_GetZoneNamebyId(Nullable<int> zONE_ID)
        //{
        //    var zONE_IDParameter = zONE_ID.HasValue ?
        //        new ObjectParameter("ZONE_ID", zONE_ID) :
        //        new ObjectParameter("ZONE_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("zone_GetZoneNamebyId", zONE_IDParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> zone_insert(Nullable<int> zONE_ID, string zONE_NAME, string zONE_CODE, string zONE_DES, Nullable<bool> zONE_STATUS)
        //{
        //    var zONE_IDParameter = zONE_ID.HasValue ?
        //        new ObjectParameter("ZONE_ID", zONE_ID) :
        //        new ObjectParameter("ZONE_ID", typeof(int));

        //    var zONE_NAMEParameter = zONE_NAME != null ?
        //        new ObjectParameter("ZONE_NAME", zONE_NAME) :
        //        new ObjectParameter("ZONE_NAME", typeof(string));

        //    var zONE_CODEParameter = zONE_CODE != null ?
        //        new ObjectParameter("ZONE_CODE", zONE_CODE) :
        //        new ObjectParameter("ZONE_CODE", typeof(string));

        //    var zONE_DESParameter = zONE_DES != null ?
        //        new ObjectParameter("ZONE_DES", zONE_DES) :
        //        new ObjectParameter("ZONE_DES", typeof(string));

        //    var zONE_STATUSParameter = zONE_STATUS.HasValue ?
        //        new ObjectParameter("ZONE_STATUS", zONE_STATUS) :
        //        new ObjectParameter("ZONE_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("zone_insert", zONE_IDParameter, zONE_NAMEParameter, zONE_CODEParameter, zONE_DESParameter, zONE_STATUSParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> zone_IsExist(string zONE_CODE)
        //{
        //    var zONE_CODEParameter = zONE_CODE != null ?
        //        new ObjectParameter("ZONE_CODE", zONE_CODE) :
        //        new ObjectParameter("ZONE_CODE", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("zone_IsExist", zONE_CODEParameter);
        //}

        //public virtual int zone_update(Nullable<int> zONE_ID, string zONE_NAME, string zONE_CODE, string zONE_DES, Nullable<bool> zONE_STATUS)
        //{
        //    var zONE_IDParameter = zONE_ID.HasValue ?
        //        new ObjectParameter("ZONE_ID", zONE_ID) :
        //        new ObjectParameter("ZONE_ID", typeof(int));

        //    var zONE_NAMEParameter = zONE_NAME != null ?
        //        new ObjectParameter("ZONE_NAME", zONE_NAME) :
        //        new ObjectParameter("ZONE_NAME", typeof(string));

        //    var zONE_CODEParameter = zONE_CODE != null ?
        //        new ObjectParameter("ZONE_CODE", zONE_CODE) :
        //        new ObjectParameter("ZONE_CODE", typeof(string));

        //    var zONE_DESParameter = zONE_DES != null ?
        //        new ObjectParameter("ZONE_DES", zONE_DES) :
        //        new ObjectParameter("ZONE_DES", typeof(string));

        //    var zONE_STATUSParameter = zONE_STATUS.HasValue ?
        //        new ObjectParameter("ZONE_STATUS", zONE_STATUS) :
        //        new ObjectParameter("ZONE_STATUS", typeof(bool));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("zone_update", zONE_IDParameter, zONE_NAMEParameter, zONE_CODEParameter, zONE_DESParameter, zONE_STATUSParameter);
        //}

        //public virtual ObjectResult<department_GetAllVisible_Result> department_GetAllVisible()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<department_GetAllVisible_Result>("department_GetAllVisible");
        //}

        //public virtual ObjectResult<detail_sale_GetByTS_Result> detail_sale_GetByTS(Nullable<int> tS_ID)
        //{
        //    var tS_IDParameter = tS_ID.HasValue ?
        //        new ObjectParameter("TS_ID", tS_ID) :
        //        new ObjectParameter("TS_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<detail_sale_GetByTS_Result>("detail_sale_GetByTS", tS_IDParameter);
        //}

        //public virtual ObjectResult<device_type_GetAllVisible_Result> device_type_GetAllVisible()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<device_type_GetAllVisible_Result>("device_type_GetAllVisible");
        //}

        //public virtual ObjectResult<employees_FindInfoByAccId_Result> employees_FindInfoByAccId(Nullable<int> aCC_ID)
        //{
        //    var aCC_IDParameter = aCC_ID.HasValue ?
        //        new ObjectParameter("ACC_ID", aCC_ID) :
        //        new ObjectParameter("ACC_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<employees_FindInfoByAccId_Result>("employees_FindInfoByAccId", aCC_IDParameter);
        //}

        //public virtual ObjectResult<holiday_GetAllVisible_Result> holiday_GetAllVisible()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<holiday_GetAllVisible_Result>("holiday_GetAllVisible");
        //}

        //public virtual ObjectResult<statistic_test_xemhoadon_Result> statistic_test_xemhoadon(string tS_NO)
        //{
        //    var tS_NOParameter = tS_NO != null ?
        //        new ObjectParameter("TS_NO", tS_NO) :
        //        new ObjectParameter("TS_NO", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_test_xemhoadon_Result>("statistic_test_xemhoadon", tS_NOParameter);
        //}

        //public virtual ObjectResult<statistic_zone_Result> statistic_zone()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_zone_Result>("statistic_zone");
        //}

        //public virtual ObjectResult<ticket_sale_getBillbyTS_ID_Result> ticket_sale_getBillbyTS_ID(Nullable<long> tS_ID)
        //{
        //    var tS_IDParameter = tS_ID.HasValue ?
        //        new ObjectParameter("TS_ID", tS_ID) :
        //        new ObjectParameter("TS_ID", typeof(long));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ticket_sale_getBillbyTS_ID_Result>("ticket_sale_getBillbyTS_ID", tS_IDParameter);
        //}

        //public virtual ObjectResult<time_frame_GetAllVisible_Result> time_frame_GetAllVisible()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<time_frame_GetAllVisible_Result>("time_frame_GetAllVisible");
        //}

        //public virtual ObjectResult<userInfo_FindInfobyId_Result> userInfo_FindInfobyId(Nullable<int> uSER_ID)
        //{
        //    var uSER_IDParameter = uSER_ID.HasValue ?
        //        new ObjectParameter("USER_ID", uSER_ID) :
        //        new ObjectParameter("USER_ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<userInfo_FindInfobyId_Result>("userInfo_FindInfobyId", uSER_IDParameter);
        //}

        //public virtual ObjectResult<Nullable<int>> holiday_findHoliday2()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("holiday_findHoliday2");
        //}

        //public virtual ObjectResult<Nullable<long>> statistic_DoanhThu_TongThucThu(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("statistic_DoanhThu_TongThucThu", sTART_DATEParameter, eND_DATEParameter);
        //}

        //public virtual ObjectResult<barcode_GetAll_Result> barcode_GetAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<barcode_GetAll_Result>("barcode_GetAll");
        //}

        //public virtual ObjectResult<statistic_ThongKeVeChuaSuDung_Result> statistic_ThongKeVeChuaSuDung(Nullable<System.DateTime> sTART_APPLY_DATE, Nullable<System.DateTime> eND_APPLY_DATE)
        //{
        //    var sTART_APPLY_DATEParameter = sTART_APPLY_DATE.HasValue ?
        //        new ObjectParameter("START_APPLY_DATE", sTART_APPLY_DATE) :
        //        new ObjectParameter("START_APPLY_DATE", typeof(System.DateTime));

        //    var eND_APPLY_DATEParameter = eND_APPLY_DATE.HasValue ?
        //        new ObjectParameter("END_APPLY_DATE", eND_APPLY_DATE) :
        //        new ObjectParameter("END_APPLY_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_ThongKeVeChuaSuDung_Result>("statistic_ThongKeVeChuaSuDung", sTART_APPLY_DATEParameter, eND_APPLY_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_ThongKeVeTonKho_Result> statistic_ThongKeVeTonKho(Nullable<System.DateTime> sTART_APPLY_DATE, Nullable<System.DateTime> eND_APPLY_DATE)
        //{
        //    var sTART_APPLY_DATEParameter = sTART_APPLY_DATE.HasValue ?
        //        new ObjectParameter("START_APPLY_DATE", sTART_APPLY_DATE) :
        //        new ObjectParameter("START_APPLY_DATE", typeof(System.DateTime));

        //    var eND_APPLY_DATEParameter = eND_APPLY_DATE.HasValue ?
        //        new ObjectParameter("END_APPLY_DATE", eND_APPLY_DATE) :
        //        new ObjectParameter("END_APPLY_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_ThongKeVeTonKho_Result>("statistic_ThongKeVeTonKho", sTART_APPLY_DATEParameter, eND_APPLY_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_DoanhThuTheoKhuVuc1_Result> statistic_DoanhThuTheoKhuVuc1(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_DoanhThuTheoKhuVuc1_Result>("statistic_DoanhThuTheoKhuVuc1", sTART_DATEParameter, eND_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_DoanhThuTheoLoaiVe1_Result> statistic_DoanhThuTheoLoaiVe1(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_DoanhThuTheoLoaiVe1_Result>("statistic_DoanhThuTheoLoaiVe1", sTART_DATEParameter, eND_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_DoanhThuTheoKhuVucQuaThoiGian_Result> statistic_DoanhThuTheoKhuVucQuaThoiGian(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_DoanhThuTheoKhuVucQuaThoiGian_Result>("statistic_DoanhThuTheoKhuVucQuaThoiGian", sTART_DATEParameter, eND_DATEParameter);
        //}

        //public virtual ObjectResult<statistic_DoanhThuTheoKhuVucQuaThoiGian_1_Result> statistic_DoanhThuTheoKhuVucQuaThoiGian_1(Nullable<System.DateTime> sTART_DATE, Nullable<System.DateTime> eND_DATE)
        //{
        //    var sTART_DATEParameter = sTART_DATE.HasValue ?
        //        new ObjectParameter("START_DATE", sTART_DATE) :
        //        new ObjectParameter("START_DATE", typeof(System.DateTime));

        //    var eND_DATEParameter = eND_DATE.HasValue ?
        //        new ObjectParameter("END_DATE", eND_DATE) :
        //        new ObjectParameter("END_DATE", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<statistic_DoanhThuTheoKhuVucQuaThoiGian_1_Result>("statistic_DoanhThuTheoKhuVucQuaThoiGian_1", sTART_DATEParameter, eND_DATEParameter);
        //}
    }
}
