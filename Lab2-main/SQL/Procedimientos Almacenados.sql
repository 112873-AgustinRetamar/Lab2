--1- Promedio de las notas parciales de los alumnos del corriente año
create proc SP_PROMEDIO_AÑO_MATERIA
	@idMateria int
as
begin
	select a.legajo Legajo, a.ape_alumno + ' ' + a.nom_alumno 'Alumno', avg(nota) Nota
	from examenes e 
	join alumnos a on a.legajo = e.legajo
	join materias m on e.id_materia = m.id_materia	
	where year(fecha) = year(getdate()) and id_tipo = 1 and m.id_materia = @idMateria
	group by a.legajo, a.ape_alumno, a.nom_alumno
	order by a.ape_alumno	
end
go

--2- Consultar alumnos en un rango de edad determinado
create proc SP_ALUMNOS_RANGO_EDAD
	@edad1 int,
	@edad2 int
as
begin
	select legajo 'Legajo', ape_alumno + ' ' + nom_alumno as 'Alumno', DateDiff(DAY,fecha_nac,GETDATE())/365 'Edad' 
	from alumnos a
	where DateDiff(DAY,fecha_nac,GETDATE())/365 between @edad1 and @edad2
	order by fecha_nac
end
go


--3- Consultar alumnos que estudien Ingeniera Civil
create proc SP_ALUMNOS_CARRERAS
	@idCarrera int
as
begin
	select a.legajo Legajo, a.ape_alumno+ ' ' + a.nom_alumno as 'Alumno'
	from alumnos a 
	join carrerasxalumnos ca on a.legajo = ca.legajo
	join carreras c on ca.id_carrera = c.id_carrera
	where c.id_carrera = @idCarrera 
	order by a.ape_alumno
end
go

--4- Consultar alumnos con inasistencias en este año de la materia de química
create proc SP_ALMUNOS_INASISTENCIAS_POR_MATERIA
	@idMateria int
as
begin
	select a.legajo Legajo, a.nom_alumno + a.ape_alumno as 'Alumno', count(*) 'Inasistencias'
	from examenes e 
	join alumnos a on a.legajo=e.legajo 
	join materias m on m.id_materia=e.id_materia	
	where id_tipo = 3 and nota = 0 and year(fecha)=year(getdate()) and m.id_materia = @idMateria
	group by a.legajo ,a.ape_alumno, a.nom_alumno
	order by Alumno
end
go

--5- Consultar lista de alumnos que aprobaron finales en el corriente año de una materia ingresada
create proc SP_FINALES_APROBADOS
	@idMateria int
as
begin
	select a.legajo 'Legajo', a.ape_alumno + ' '+ a.nom_alumno as 'Alumno'
	from examenes e 
	join alumnos a on a.legajo = e.legajo 
	join materias m on e.id_examen = m.id_materia
	where id_tipo = 2 and nota >= 6 and m.id_materia = @idMateria and YEAR(e.fecha) = YEAR(GETDATE())
end
go

--6- Emitir un listado de los alumnos que se hayan matriculado este año incluyendo solo a aquellos cuyo legajo oscile entre 110000 y 115000.
create proc SP_MATRICULAS_POR_RANGO_LEGAJO
	@lMin int,
	@lMax int
as
begin
	select legajo 'Legajo', nom_alumno + ape_alumno as 'Alumno'
	from alumnos
	where legajo in(select m.legajo 
					from alumnos a 
					join matriculas m on a.legajo=m.legajo
					where year(fecha)=year(getdate()))
	and legajo between @lMin and @lMax
end
go

--7- Consultar las materias a las que está inscrito un alumno
create proc SP_INSCIP_MATERIAS_ALUMNO
	@legajo int
as
begin
	select mate.nom_materia as 'Materia'
	from matriculasXmaterias mxm 
	join materias mate on mate.id_materia=mxm.id_materia
	join matriculas matr on mxm.id_matricula=matr.id_matricula 
	join alumnos a on matr.legajo=a.legajo
	where a.legajo = @legajo
	order by 1
end
go

--8- Listado de docentes que dan una materia
create proc SP_DOCENTES_POR_MATERIA
	@idMateria int
as
begin
	select d.legajo Legajo, d.nom_docente+' '+d.ape_docente 'Nombre'
	from docentes d
	join materiasXdocentes mxd on d.legajo = mxd.legajo
	join materias m on m.id_carrera = mxd.id_materia
	where m.id_materia = @idMateria
end
go

create proc SP_CONSULTAR_MATERIAS
as
begin
	select id_materia, nom_materia
	from materias
end
go

create proc SP_CONSULTAR_CARRRERAS
as
begin
	select id_carrera, nom_carrera
	from carreras
end
go


	

