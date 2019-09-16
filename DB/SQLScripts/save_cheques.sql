create proc save_cheques
@cheque_id uniqueidentifier,
@cheque_number nvarchar(50),
@summ money,
@discount money,
@articles nvarchar(max)
as
insert into cheques values(@cheque_id, @cheque_number, @summ, @discount, @articles);
