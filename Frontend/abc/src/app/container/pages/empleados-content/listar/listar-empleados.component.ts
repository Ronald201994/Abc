import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { Empleado } from 'src/app/interfaces/empleado.interface';
import { EmpleadoService } from 'src/app/services/empleado.service';

@Component({
    selector: 'app-listar-empleados',
    templateUrl: './listar-empleados.component.html',
    styleUrls: ['./listar-empleados.component.scss']
})
export class ListarEmpleadosComponent implements OnInit, OnDestroy {
    private dataSubscription: Subscription = Subscription.EMPTY;
    productsList: Empleado[] = [];
    displayedColumns: string[] = ['Id', 'Nombre'];
    dataSource = new MatTableDataSource<Empleado>();
    @ViewChild(MatPaginator) paginator!: MatPaginator;
    @ViewChild(MatSort) sort!: MatSort;

    constructor(
        private _empleadoService: EmpleadoService,
        public dialog: MatDialog
    ) { }

    ngOnInit(): void {
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
        this.getEmpleados();
    }

    getEmpleados() {
        this.dataSubscription = this._empleadoService.getEmpleados().subscribe(result => {
            this.productsList = result;
            this.recargarTabla();
        })
    }

    addEmpleado() {
        const dialogRef = this.dialog.open(Object, {
            width: '300px'
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result) {
                let request: any = {
                    
                }
                this._empleadoService.addEmpleado(request).subscribe(result => {
                    this.getEmpleados();
                })
            }
        });
    }

    recargarTabla() {
        this.dataSource = new MatTableDataSource<Empleado>(this.productsList);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    }

    ngOnDestroy(): void {
        if (this.dataSubscription) {
          this.dataSubscription.unsubscribe();
        }
    }
}
