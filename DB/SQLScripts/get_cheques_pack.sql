create proc get_cheques_pack
@pack_size integer
as
select top (@pack_size) * from Cheques order by cheque_id desc
