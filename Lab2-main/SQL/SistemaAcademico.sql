create database SistemaAcademico
GO
use SistemaAcademico
GO
SET DATEFORMAT DMY
--Provincias--
create table provincias(
id_provincia tinyint not null,
nom_provincia varchar(30) not null,
constraint pk_provincias primary key (id_provincia)
)
GO
--Localidades--
create table localidades(
id_localidad smallint not null,
nom_localidad varchar(30)  not null,
id_provincia tinyint not null,
constraint pk_localidades primary key (id_localidad),
constraint fk_prov_local foreign key (id_provincia)
	references provincias(id_provincia)
)
GO
--Barrios--
create table barrios(
id_barrio int,
nom_barrio varchar(30) not null,
id_localidad smallint not null, 
constraint pk_barrios primary key (id_barrio),
constraint fk_local_barrios foreign key (id_localidad)
	references localidades(id_localidad)
)
GO
--Alumnos--
create table alumnos(
legajo int,
nom_alumno varchar(100),
ape_alumno varchar(100),
calle varchar(100),
telefono varchar(20),
email varchar(150),
id_barrio int,
constraint pk_legajo_alum primary key (legajo),
constraint fk_barrio_alum foreign key (id_barrio)
	references barrios(id_barrio)
)
GO
--Docentes--
create table docentes(
legajo int,
nom_docente varchar(100),
ape_docente varchar(100),
calle varchar(100),
telefono varchar(20),
email varchar(150),
id_barrio int,
constraint pk_legajo_doc primary key (legajo),
constraint fk_barrio_doc foreign key (id_barrio)
	references barrios(id_barrio)
)
GO
--Carreras--
create table carreras(
id_carrera tinyint,
nom_carrera varchar(100)
constraint pk_carrera primary key (id_carrera)
)
GO
--Carreras por Alumnos--
create table carrerasXalumnos(
id_carrera tinyint,
legajo int,
constraint pk_carreraXalumno primary key (id_carrera, legajo),
constraint fk_carrera_alumno foreign key (id_carrera)
	references carreras(id_carrera),
constraint fk_legajo_alum_carrera foreign key (legajo)
	references alumnos(legajo)
)
GO
--Cursos--
create table cursos(
id_curso int,
codigo varchar(5),
constraint pk_curso primary key (id_curso)
)
GO
--Materias--
create table materias(
id_materia int,
nom_materia varchar(75),
id_carrera tinyint,
constraint pk_materia primary key (id_materia),
constraint fk_carrera_materia foreign key (id_carrera)
	references carreras(id_carrera)
)
GO
--Tipo Nota--
create table tipoNotas(
id_tipo tinyint,
nom_tipo varchar(25),
constraint pk_tipo_nota primary key (id_tipo)
)
GO
--Materias por docentes--
create table materiasXdocentes(
id_materia int,
legajo int,
constraint pk_materias_docentes primary key (id_materia, legajo),
constraint fk_materia_docente foreign key (id_materia)
	references materias(id_materia),
constraint fk_legajo_doc_materia foreign key (legajo)
	references docentes(legajo)
)
GO
--Materias por cursos--
create table materiasXcursos(
id_curso int,
id_materia int,
constraint pk_materias_cursos primary key (id_curso, id_materia),
constraint fk_curso_materia foreign key (id_curso)
	references cursos(id_curso),
constraint fk_materia_curso foreign key (id_materia)
	references materias(id_materia)
)
GO
--Examenes--
create table examenes(
id_examen int,
id_tipo tinyint,
fecha date,
nota tinyint,
id_materia int,
legajo int,
constraint pk_examen primary key (id_examen),
constraint fk_tipo_examen foreign key (id_tipo)
	references tipoNotas (id_tipo),
constraint fk_legajo_alum_examen foreign key (legajo)
	references alumnos(legajo),
constraint fk_materia_examen foreign key (id_materia)
	references materias(id_materia)
)
GO
--Matriculas--
create table matriculas(
id_matricula int,
legajo int,
fecha date,
constraint pk_matricula primary key (id_matricula),
constraint fk_legajo_alum_matri foreign key (legajo)
	references alumnos(legajo)
)
GO
--Matriculas por Materias--
create table matriculasXmaterias(
id_materia int,
id_matricula int,
condicion varchar(20),
constraint pk_matriculas_materias primary key (id_materia, id_matricula),
constraint fk_materia_matricula foreign key (id_materia)
	references materias(id_materia),
constraint fk_matricula_materia foreign key(id_matricula)
	references matriculas(id_matricula)
)
