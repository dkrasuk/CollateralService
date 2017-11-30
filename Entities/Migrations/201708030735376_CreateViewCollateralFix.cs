namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateViewCollateralFix : DbMigration
    {
        public override void Up()
        {
            this.Sql(@"
                    CREATE OR REPLACE VIEW CollateralsEvaluations AS
                    select 
                    c.id as CollateralId,
                    cc.Value as Value_Evaluation,
                    cc.Currency,
                    TO_DATE(SUBSTR(cc.Date_Evaluation,1,17),'YYYY-MM-DD""T""HH24:MI:SS') as Date_Evaluation,
                    cc.Source,
                    cc.Responsible,
                    TO_DATE(SUBSTR(cc.DateEntry, 1, 17), 'YYYY-MM-DD""T""HH24:MI:SS') as DateEntry

                           from collateral c,
                                JSON_TABLE(c.body, '$' NULL ON ERROR
                                                   columns(
                                                           nested path '$.EvaluationHistory[*]'
                                                                  columns(
                                                                          IdEvaluation varchar(40) path '$.Id',
                                                                          Value path '$.Value.Value',
                                                                          Currency path '$.Value.Currency.Name',
                                                                          Date_Evaluation path '$.Date',
                                                                          Source path '$.Source.Name',
                                                                          Responsible path '$.Responsible',
                                                                          DateEntry path '$.DateEntry'
                                                                  )
                                                            )
                                ) cc


                    ");

            this.Sql(@"
                    CREATE OR REPLACE VIEW CollateralHistory AS
                    select 
                    c.id as CollateralId,
                    cc.SettlementType,
                    cc.Settlement,
                    cc.Region,
                    cc.Street,
                    cc.House,
                    cc.Apartment,
                    cc.NumberOfRooms as NumberOfRooms,
                    cc.TotalArea as TotalArea,
                    cc.LandArea as LandArea,
                    cc.Appointment,
                    cc.Pledgers,
                    cc.Type,
                    cc.Subtype,
                    cc.Description,
                    cc.ActualDescription,
                    cc.Deleted,
                    cc.Status,
                    cc.EvaluationDate,
                    cc.IsActive,
                    cc.Moratorium,
                    cc.IsVerified,
                    cc.IsAdditionalProperty,
                    cc.Comments,
                    cc.CreateUser,
                    TO_DATE(SUBSTR(cc.EntryDate, 1, 17), 'YYYY-MM-DD""T""HH24:MI:SS') as EntryDate,
                    TO_DATE(SUBSTR(cc.SetamDate,1,17), 'YYYY-MM-DD""T""HH24:MI:SS') as SetamDate,
                    TO_DATE(SUBSTR(cc.BiddingDate, 1, 17), 'YYYY-MM-DD""T""HH24:MI:SS') as BiddingDate,
                    TO_DATE(SUBSTR(cc.InventoryDate, 1, 17), 'YYYY-MM-DD""T""HH24:MI:SS') as InventoryDate,
                    TO_DATE(SUBSTR(cc.SaleDate, 1, 17), 'YYYY-MM-DD""T""HH24:MI:SS') as SaleDate,                    
                    TO_DATE(SUBSTR(cc.ModifyDate, 1, 17), 'YYYY-MM-DD""T""HH24:MI:SS') as ModifyDate,
                    cc.ModifyUser,
                    cc.SaleType,
                    cc.State,
                    cc.BodyType,
                    cc.Brand,
                    cc.Model,
                    cc.StateNumber,
                    cc.VinCode,
                    cc.YearIssue,
                    cc.Color,
                    cc.Engine,
                    cc.GearBox,
                    cc.CarRegion,
                    cc.Specification

                    from collateral c,
                    json_table(c.history, '$' NULL ON ERROR
                                          columns(
                                                   nested path '$.CollateralHistory[*]'
                                                   columns(
                                                            Id varchar path '$.Id',
                                                            SettlementType varchar(40) path '$.SettlementType.Name',
                                                            Region varchar(40) path '$.Region.Name',
                                                            Settlement varchar(40) path '$.Settlement.Name',
                                                            Street varchar(40) path '$.Street',
                                                            House varchar(40) path '$.House',
                                                            Apartment varchar(40) path '$.Apartment',
                                                            NumberOfRooms varchar(40) path '$.NumberOfRooms',
                                                            TotalArea varchar(40) path '$.TotalArea',
                                                            LandArea varchar(40) path '$.LandArea',
                                                            Appointment varchar(50) path '$.Appointment.Name',
                                                            Pledgers varchar(40) path '$.Pledgers',
                                                            Type varchar(40) path '$.Type.Name',
                                                            Subtype varchar(40) path '$.Subtype.Name',
                                                            Description varchar path '$.Description',
                                                            ActualDescription varchar path '$.ActualDescription',
                                                            Deleted varchar(10) path '$.Deleted',
                                                            EvaluationDate varchar(40) path '$.EvaluationDate',
                                                            Status varchar path '$.Status.Name',
                                                            IsActive varchar path '$.IsActive',
                                                            Moratorium varchar path '$.Moratorium.Name',
                                                            IsVerified varchar path '$.IsVerified',
                                                            IsAdditionalProperty varchar path '$.IsAdditionalProperty',
                                                            SetamDate varchar(40) path '$.SetamDate',
                                                            BiddingDate varchar(40) path '$.BiddingDate',
                                                            InventoryDate varchar(40) path '$.InventoryDate',
                                                            SaleDate varchar(40) path '$.SaleDate',
                                                            EntryDate varchar(40) path '$.EntryDate',
                                                            ModifyDate varchar(40) path '$.ModifyDate',
                                                            ModifyUser varchar(40) path '$.ModifyUser',
                                                            State varchar(40) path '$.State.Name',
                                                            SaleType varchar(40) path '$.SaleType.Name',
                                                            Comments varchar path '$.Comment',
                                                            CreateUser varchar path '$.User',
                                                            BodyType varchar path '$.BodyType.Name',
                                                            Brand varchar path '$.Brand.Name',
                                                            Model varchar path '$.Model.Name',
                                                            StateNumber varchar path '$.StateNumber',
                                                            VinCode varchar path '$.VinCode',
                                                            YearIssue varchar path '$.YearIssue',
                                                            Color varchar path '$.Color.Name',
                                                            Engine varchar path '$.Engine',
                                                            GearBox varchar path '$.GearBox.Name',
                                                            CarRegion varchar path '$.Region.Name',
                                                            Specification varchar path '$.Specification',
                                                            ord for ordinality
                                                            )))cc
                    ");
            this.Sql(@"
                    CREATE OR REPLACE VIEW Collaterals AS
                    select 
                    to_number(cca.creditagreementid) as creditagreementid,   
                    to_number(ca.collateralagreementid) as collateralagreementid,
                    c.id as CollateralId,
                    cag.""Number"" as CollateralNumberSource,
                    cag.opendate,
                    cag.closedate,
                    cag.personid,
                    cc.SettlementType,
                    cc.Settlement,
                    cc.Region,
                    cc.Street,
                    cc.House,
                    cc.Apartment,
                    cc.NumberOfRooms as NumberOfRooms,
                    cc.TotalArea as TotalArea,
                    cc.LandArea as LandArea,
                    cc.Appointment,
                    cc.Pledgers,
                    cc.Type,
                    cc.Subtype,
                    cc.Description,
                    cc.ActualDescription,
                    cc.Deleted,
                    cc.Status,
                    cc.EvaluationDate,
                    cc.IsActive,
                    cc.Moratorium,
                    cc.IsVerified,
                    cc.IsAdditionalProperty,
                    cc.Comments,
                    cc.CreateUser,
                    TO_DATE(SUBSTR(cc.EntryDate, 1, 17), 'YYYY-MM-DD""T""HH24:MI:SS') as EntryDate,
                    TO_DATE(SUBSTR(cc.SetamDate, 1, 17), 'YYYY-MM-DD""T""HH24:MI:SS') as SetamDate,
                    TO_DATE(SUBSTR(cc.BiddingDate, 1, 17), 'YYYY-MM-DD""T""HH24:MI:SS') as BiddingDate,
                    TO_DATE(SUBSTR(cc.InventoryDate, 1, 17), 'YYYY-MM-DD""T""HH24:MI:SS') as InventoryDate,
                    TO_DATE(SUBSTR(cc.SaleDate, 1, 17), 'YYYY-MM-DD""T""HH24:MI:SS') as SaleDate,                    
                    TO_DATE(SUBSTR(cc.ModifyDate, 1, 17), 'YYYY-MM-DD""T""HH24:MI:SS') as ModifyDate,
                    cc.ModifyUser,                    
                    cc.SaleType,
                    cc.State,
                    cc.BodyType,
                    cc.Brand,
                    cc.Model,
                    cc.StateNumber,
                    cc.VinCode,
                    cc.YearIssue,
                    cc.Color,
                    cc.Engine,
                    cc.GearBox,
                    cc.CarRegion,
                    cc.Specification

                    from collateral c
                    left join COLLATERAL_COLLGREEMENTS ca on c.id = ca.collateralid  
                    left join COLLAGREEMENTS_CREDAGREEMENTS cca on ca.collateralagreementid = cca.collateralagreementid
                    left join collateralagreements cag on cca.collateralagreementid = cag.id,

                                json_table(c.body, '$' NULL ON ERROR
                                                   columns(
                                                            SettlementType varchar(40) path '$.SettlementType.Name',
                                                            Region varchar(40) path '$.Region.Name',
                                                            Settlement varchar(40) path '$.Settlement.Name',
                                                            Street varchar(40) path '$.Street',
                                                            House varchar(40) path '$.House',
                                                            Apartment varchar(40) path '$.Apartment',
                                                            NumberOfRooms varchar(40) path '$.NumberOfRooms',
                                                            TotalArea varchar(40) path '$.TotalArea',
                                                            LandArea varchar(40) path '$.LandArea',
                                                            Appointment varchar(50) path '$.Appointment.Name',
                                                            Pledgers varchar(40) path '$.Pledgers',
                                                            Type varchar(40) path '$.Type.Name',
                                                            Subtype varchar(40) path '$.Subtype.Name',
                                                            Description varchar path '$.Description',
                                                            ActualDescription varchar path '$.ActualDescription',
                                                            Deleted varchar(10) path '$.Deleted',
                                                            EvaluationDate varchar(40) path '$.EvaluationDate',
                                                            Status varchar path '$.Status.Name',
                                                            IsActive varchar path '$.IsActive',
                                                            Moratorium varchar path '$.Moratorium.Name',
                                                            IsVerified varchar path '$.IsVerified',
                                                            IsAdditionalProperty varchar path '$.IsAdditionalProperty',
                                                            SetamDate varchar(40) path '$.SetamDate',
                                                            BiddingDate varchar(40) path '$.BiddingDate',
                                                            InventoryDate varchar(40) path '$.InventoryDate',
                                                            SaleDate varchar(40) path '$.SaleDate',
                                                            EntryDate varchar(40) path '$.EntryDate',
                                                            ModifyDate varchar(40) path '$.ModifyDate',
                                                            ModifyUser varchar(40) path '$.ModifyUser',
                                                            State varchar(40) path '$.State.Name',
                                                            SaleType varchar(40) path '$.SaleType.Name',
                                                            Comments varchar path '$.Comment',
                                                            CreateUser varchar path '$.User',
                                                            BodyType varchar path '$.BodyType.Name',
                                                            Brand varchar path '$.Brand.Name',
                                                            Model varchar path '$.Model.Name',
                                                            StateNumber varchar path '$.StateNumber',
                                                            VinCode varchar path '$.VinCode',
                                                            YearIssue varchar path '$.YearIssue',
                                                            Color varchar path '$.Color.Name',
                                                            Engine varchar path '$.Engine',
                                                            GearBox varchar path '$.GearBox.Name',
                                                            CarRegion varchar path '$.Region.Name',
                                                            Specification varchar path '$.Specification',
                                                                                  ord for ordinality)) cc
                    ");
        }
        
        public override void Down()
        {
            this.Sql("DROP VIEW CollateralHistory");
            this.Sql("DROP VIEW Collaterals");
            this.Sql("DROP VIEW CollateralsEvaluations");
        }
    }
}
