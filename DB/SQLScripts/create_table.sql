create table Cheques
(
cheque_id uniqueidentifier not null,
cheque_number nvarchar(50),
summ money,
discount money,
articles nvarchar(max)
)
