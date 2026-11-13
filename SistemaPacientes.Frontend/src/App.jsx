
import { useEffect, useState } from 'react'
import './App.css'

const API = 'https://localhost:7259/api/Pacientes'

const formularioInicial = {
    nombre: '',
    apellido: '',
    cedula: '',
    fechaNacimiento: '',
    telefono: '',
    direccion: ''
}

function App() {
    const [pacientes, setPacientes] = useState([])
    const [formulario, setFormulario] = useState(formularioInicial)
    const [editando, setEditando] = useState(null)
    const [cargando, setCargando] = useState(true)
    const [error, setError] = useState('')

    const cargarPacientes = async () => {
        try {
            const respuesta = await fetch(API)

            if (!respuesta.ok) {
                throw new Error('No se pudieron cargar los pacientes.')
            }

            const datos = await respuesta.json()
            setPacientes(datos)
            setError('')
        } catch {
            setError('No fue posible conectar con la API.')
        } finally {
            setCargando(false)
        }
    }

    useEffect(() => {
        cargarPacientes()
    }, [])

    const manejarCambio = (e) => {
        setFormulario({
            ...formulario,
            [e.target.name]: e.target.value
        })
    }

    const guardarPaciente = async (e) => {
        e.preventDefault()

        const paciente = {
            ...formulario,
            id: editando ?? 0,
            fechaNacimiento: new Date(
                formulario.fechaNacimiento
            ).toISOString()
        }

        try {
            const respuesta = await fetch(
                editando !== null ? `${API}/${editando}` : API,
                {
                    method: editando !== null ? 'PUT' : 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(paciente)
                }
            )

            if (!respuesta.ok) {
                throw new Error('No se pudo guardar el paciente.')
            }

            setFormulario(formularioInicial)
            setEditando(null)
            await cargarPacientes()

        } catch (error) {
            alert(error.message)
        }
    }

    const editarPaciente = (paciente) => {
        setEditando(paciente.id)

        setFormulario({
            nombre: paciente.nombre || '',
            apellido: paciente.apellido || '',
            cedula: paciente.cedula || '',
            fechaNacimiento: paciente.fechaNacimiento?.substring(0, 10) || '',
            telefono: paciente.telefono || '',
            direccion: paciente.direccion || ''
        })

        window.scrollTo(0, 0)
    }

    const eliminarPaciente = async (id) => {
        if (!window.confirm('¿Deseas eliminar este paciente?')) {
            return
        }

        try {
            const respuesta = await fetch(`${API}/${id}`, {
                method: 'DELETE'
            })

            if (!respuesta.ok) {
                throw new Error('No se pudo eliminar el paciente.')
            }

            await cargarPacientes()
        } catch (error) {
            alert(error.message)
        }
    }

    const cancelarEdicion = () => {
        setFormulario(formularioInicial)
        setEditando(null)
    }

    return (
        <div className="app">
            <aside className="sidebar">
                <h2>🏥 SistemaPacientes</h2>

                <nav>
                    <a href="#inicio">Inicio</a>
                    <a href="#pacientes">Pacientes</a>
                    <a href="#medicos">Médicos</a>
                    <a href="#citas">Citas</a>
                    <a href="#especialidades">Especialidades</a>
                    <a href="#consultorios">Consultorios</a>
                    <a href="#historiales">Historiales médicos</a>
                    <a href="#recetas">Recetas</a>
                    <a href="#medicamentos">Medicamentos</a>
                    <a href="#usuarios">Usuarios</a>
                    <a href="#roles">Roles</a>
                </nav>
            </aside>

            <main className="main-content" id="inicio">
                <header>
                    <h1>Panel principal</h1>
                    <p>Sistema de Gestión de Pacientes</p>
                </header>

                <section className="welcome">
                    <h2>¡Bienvenido!</h2>
                    <p>
                        Administra la información de tu sistema
                        desde un solo lugar.
                    </p>
                </section>

                <section className="dashboard">
                    <div className="card">
                        <h3>Pacientes</h3>
                        <p>{pacientes.length} pacientes registrados</p>
                    </div>

                    <div className="card">
                        <h3>Médicos</h3>
                        <p>Gestión del personal médico</p>
                    </div>

                    <div className="card">
                        <h3>Citas</h3>
                        <p>Administración de citas médicas</p>
                    </div>

                    <div className="card">
                        <h3>Especialidades</h3>
                        <p>Gestión de especialidades médicas</p>
                    </div>
                </section>

                <section className="welcome" id="pacientes">
                    <h2>
                        {editando
                            ? 'Editar paciente'
                            : 'Registrar paciente'}
                    </h2>

                    <form onSubmit={guardarPaciente}>
                        <input
                            name="nombre"
                            placeholder="Nombre"
                            value={formulario.nombre}
                            onChange={manejarCambio}
                            required
                        />

                        <input
                            name="apellido"
                            placeholder="Apellido"
                            value={formulario.apellido}
                            onChange={manejarCambio}
                            required
                        />

                        <input
                            name="cedula"
                            placeholder="Cédula"
                            value={formulario.cedula}
                            onChange={manejarCambio}
                            required
                        />

                        <label>Fecha de nacimiento</label>
                        <input
                            type="date"
                            name="fechaNacimiento"
                            value={formulario.fechaNacimiento}
                            onChange={manejarCambio}
                            required
                        />

                        <input
                            name="telefono"
                            placeholder="Teléfono"
                            value={formulario.telefono}
                            onChange={manejarCambio}
                            required
                        />

                        <input
                            name="direccion"
                            placeholder="Dirección"
                            value={formulario.direccion}
                            onChange={manejarCambio}
                            required
                        />

                        <button type="submit">
                            {editando
                                ? 'Guardar cambios'
                                : 'Registrar paciente'}
                        </button>

                        {editando !== null && (
                            <button
                                type="button"
                                onClick={cancelarEdicion}
                            >
                                Cancelar
                            </button>
                        )}
                    </form>
                </section>

                <section className="welcome">
                    <h2>Lista de pacientes</h2>

                    {cargando && <p>Cargando pacientes...</p>}

                    {error && <p>{error}</p>}

                    {!cargando && !error && pacientes.length === 0 && (
                        <p>No hay pacientes registrados.</p>
                    )}

                    {pacientes.map((paciente) => (
                        <div className="card" key={paciente.id}>
                            <h3>
                                {paciente.nombre} {paciente.apellido}
                            </h3>

                            <p>Cédula: {paciente.cedula}</p>
                            <p>Teléfono: {paciente.telefono}</p>
                            <p>Dirección: {paciente.direccion}</p>

                            <button
                                onClick={() => editarPaciente(paciente)}
                            >
                                Editar
                            </button>

                            <button
                                onClick={() => eliminarPaciente(paciente.id)}
                            >
                                Eliminar
                            </button>
                        </div>
                    ))}
                </section>
            </main>
        </div>
    )
}

export default App

