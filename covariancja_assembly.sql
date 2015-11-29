drop aggregate Cov
go
drop assembly Cov_a
go 

create assembly Cov_a
authorization [dbo]
from 'D:\covariancja.dll'
with permission_set = safe

go

create aggregate Cov(@x float,@y float)
returns float
external name Cov_a.COV
go
