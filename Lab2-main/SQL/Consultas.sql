--1- Promedio de las notas parciales de los alumnos del corriente año:
CREATE VIEW aprob_corr_mes
as
	select a.legajo Legajo, a.ape_alumno + ' ' + a.nom_alumno as 'Alumno', avg(nota) Nota
	from examenes e join alumnos a on a.legajo = e.legajo
	where year(fecha) = year(getdate()) and id_tipo = 1
go

--2- Consultar alumnos en un rango de edad determinado:
CREATE PROCEDURE alumnos_edad
	@edad1 int,
	@edad2 int
as
	select legajo 'Legajo', ape_alumno + ' ' + nom_alumno as 'Alumno', DateDiff(DAY,fecha_nac,GETDATE())/365 'Edad' 
	from alumnos a
	where DateDiff(DAY,fecha_nac,GETDATE())/365 between @edad1 and @edad2
go

--3- Consultar alumnos que estudien Ingeniera Civil:
CREATE VIEW alumnos_civil
as
	select a.legajo Legajo, ape_alumno+ ' ' + nom_alumno as 'Alumno', c.nom_carrera Carrera
	from alumnos a 
	join carrerasxalumnos ca on a.legajo = ca.legajo
	join carreras c on ca.id_carrera = c.id_carrera
	where c.nom_carrera like 'Ingenieria Civil'
go

--4- Consultar alumnos con inasistencias en este año de la materia de química.
select a.legajo Legajo, a.nom_alumno + a.ape_alumno as 'Alumno'
from examenes e join alumnos a on a.legajo=e.legajo join materias m on m.id_materia=e.id_materia
where id_tipo = 3 and nota = 0 and year(fecha)=year(getdate()) and m.nom_materia like 'Quimica'
order by Alumno
go

--5- Consultar lista de alumnos que aprobaron finales en el corriente año de una materia ingresada
create procedure finales_aprobados
@materia varchar(50)
as
	select a.legajo 'Legajo', a.ape_alumno + ' '+ a.nom_alumno as 'Alumno', m.nom_materia 'Materia'
	from examenes e join alumnos a on a.legajo = e.legajo join materias m on e.id_examen = m.id_materia
	where id_tipo = 2 and nota >= 6 and m.nom_materia like '@materia'
go


--6- Emitir un listado de los alumnos que se hayan matriculado este año incluyendo solo a aquellos cuyo legajo oscile entre 110000 y 115000.
select legajo 'Legajo', nom_alumno + ape_alumno as 'Alumno'
from alumnos
where legajo in(
	select m.legajo 
	from alumnos a join matriculas m 
	on a.legajo=m.legajo
	where year(fecha)=year(getdate()))
and legajo between 110000 and 115000
go

--7- Consultar las materias a las que está inscrito un alumno
select	a.legajo as 'Legajo', nom_alumno+' '+ape_alumno as 'Nombre', mat.nom_materia as 'Materia'
from alumnos a, matriculas m, matriculasXmaterias mm, materias mat
where a.legajo=m.legajo and m.id_matricula=mm.id_matricula and mm.id_materia=mat.id_materia
order by 1
go

select	a.legajo as 'Legajo', a.nom_alumno+' '+a.ape_alumno as 'Nombre', mate.nom_materia as 'Materia'
from matriculasXmaterias mxm 
join materias mate on mate.id_materia=mxm.id_materia
join matriculas matr on mxm.id_matricula=matr.id_matricula 
join alumnos a on matr.legajo=a.legajo
order by 1
go

--8- Listado de docentes y alumnos de la utn:
select legajo as 'Legajo', nom_alumno+' '+ape_alumno as 'Nombre', 'Alumno' as 'Tipo'
from alumnos
union
select legajo, nom_docente+' '+ape_docente, 'Docente'
from docentes
order by 3
go
