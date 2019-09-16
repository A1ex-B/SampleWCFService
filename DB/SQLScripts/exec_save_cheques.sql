declare @id uniqueidentifier
set @id = NEWID();

exec save_cheques @id, '4353453245243', 1000, 50, 'aaa;bbb'