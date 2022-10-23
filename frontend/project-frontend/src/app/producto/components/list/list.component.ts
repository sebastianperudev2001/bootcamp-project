import { Component, OnInit } from '@angular/core';
import { ProductoService } from "../../../services/producto.service";
import { MatTableDataSource } from "@angular/material/table";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'precio_unitario', 'categoria', 'proveedor', 'cantidad', 'actions'];
  ProductoDataSource: MatTableDataSource<any> = new MatTableDataSource<any>();

  constructor(
    private productoService: ProductoService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {

  }

  getProducto(): void {
    this.productoService.getAll().subscribe(listProducto => {
      this.ProductoDataSource.data = listProducto;
    })
  }

  editarProducto(producto: any): void {
    this.router.navigate(
      ['/producto/update/' + producto.id],
      { relativeTo: this.activatedRoute })

  }


  deleteProducto(producto: any): void {
    this.productoService.delete(producto.id).subscribe(response => {
      console.log(response);
      this.getProducto()
    })

  }

  agregarProducto(): void {
    this.router.navigate(['./create'], {
      relativeTo: this.activatedRoute
    })
  }

}
