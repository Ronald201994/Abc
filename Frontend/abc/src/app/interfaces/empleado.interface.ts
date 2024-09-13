export interface Empleado {
    id: number;
    nombre: string;
    apellidos: string;
    cargoId: number;
    nombreCargo: string;
    afpId: number;
    nombreAfp: string;
    fechaNacimiento: string | null;
    fechaIngreso: string | null;
    sueldo: number | null;
}