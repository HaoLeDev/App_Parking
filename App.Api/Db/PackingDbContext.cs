using App.Api.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace App.Api.Db
{
    public class PackingDbContext:DbContext
    {
        public PackingDbContext() : base("name= PackingEntities")
        {

        }
        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<BARCODE> BARCODEs { get; set; }
        public virtual DbSet<CARD_NO> CARD_NOs { get; set; }
        public virtual DbSet<CARD_TYPE> CARD_TYPEs { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTs { get; set; }
        public virtual DbSet<DETAIL_SALE> DETAIL_SALEs { get; set; }
        public virtual DbSet<DEVICE> DEVICEs { get; set; }
        public virtual DbSet<DEVICE_TYPE> DEVICE_TYPEs { get; set; }
        public virtual DbSet<DISCOUNT> DISCOUNTs { get; set; }

        public virtual DbSet<DISCOUNT_TYPE> DISCOUNT_TYPEs { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEEs { get; set; }
        public virtual DbSet<GAME_SPORT> GAME_SPORTs { get; set; }
        public virtual DbSet<HOLIDAY> HOLIDAYs { get; set; }
        public virtual DbSet<IO_INFO> IO_INFOs { get; set; }
        public virtual DbSet<MENULIST> MENULISTs { get; set; }
        public virtual DbSet<PRIVILE> PRIVILEs { get; set; }
        public virtual DbSet<TIME_FRAME> TICKET_FRAMEs { get; set; }
        public virtual DbSet<TICKET_PRICE> TICKET_PRICEs { get; set; }

        public virtual DbSet<TICKET_SALE> TICKET_SALEs { get; set; }
        public virtual DbSet<TICKET_TYPE> TICKET_TYPEs { get; set; }
        public virtual DbSet<TIME_FRAME_ACTIVE> TIME_FRAME_ACTIVEs { get; set; }
        public virtual DbSet<UNIT> UNITs { get; set; }
        public virtual DbSet<USER_INFO> USER_INFOs { get; set; }
        public virtual DbSet<USER_TYPE> USER_TYPEs { get; set; }
        public virtual DbSet<VISIBLECONTROL> VISIBLECONTROLs { get; set; }
        public virtual DbSet<WEEKDAY> WEEKDAYs { get; set; }
        public virtual DbSet<ZONE> ZONEs { get; set; }

    }
}