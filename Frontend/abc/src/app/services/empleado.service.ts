import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { map } from "rxjs";
import { Empleado } from "../interfaces/empleado.interface";

@Injectable({
    providedIn: 'root'
})

export class EmpleadoService {
    BaseApi: string = 'https://localhost:44358/api';
    baseUrl: string = 'empleados';
    constructor(
        private _http: HttpClient
    ) {}

    getEmpleados() {
        return this._http.get<Empleado[]>(`${this.BaseApi}/${this.baseUrl}`).pipe(
            map((result: Empleado[]) => {
                return result;
            })
        )
    }

    addEmpleado(request: Empleado) {
        return this._http.post<number>(`${this.BaseApi}/${this.baseUrl}`, request).pipe(
            map((result: number) => {
                return result;
            })
        )
    }
}