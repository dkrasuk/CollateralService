CREATE OR REPLACE VIEW CollateralsEvaluations AS
select 
c.id as CollateralId,
cc.Value as Value_Evaluation,
cc.Currency,
TO_DATE(SUBSTR(cc.Date_Evaluation,1,17),'YYYY-MM-DD"T"HH24:MI:SS') as Date_Evaluation,
cc.Source,
cc.Responsible,
TO_DATE(SUBSTR(cc.DateEntry,1,17),'YYYY-MM-DD"T"HH24:MI:SS') as DateEntry

       from collateral c,
            JSON_TABLE(c.body, '$' NULL ON ERROR
                               columns (
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