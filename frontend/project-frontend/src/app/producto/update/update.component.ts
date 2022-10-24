import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ProductoService } from 'src/app/services/producto.service';
@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit {

  formProducto: FormGroup;
  categorias: any[] = [];
  proveedores: any[] = [];

  constructor(

    private formBuilder: FormBuilder,
    private productoService: ProductoService,
    private router: Router,
    private activatedRouter: ActivatedRoute

  ) {

    this.formProducto = formBuilder.group({
      id: [{ value: null, disabled: false }, [Validators.required]],
      name: [{ value: null, disabled: false }, [Validators.required]],
      precio_unitario: [{ value: null, disabled: false }, [Validators.required]],
      categoria: [{ value: null, disabled: false }, [Validators.required]],
      proovedor: [{ value: null, disabled: false }, [Validators.required]],
      cantidad: [{ value: null, disabled: false }, [Validators.required]],

    })

  }

  ngOnInit(): void {

    this.productoService.getCategoria().subscribe(categorias => {
      this.categorias = categorias;
    })

    this.productoService.getProveedor().subscribe(proveedores => {
      this.proveedores = proveedores;
    }
    )

    this.generateData();


  }
  cancelar(): void {
    this.back();
  }

  back(): void {
    this.router.navigate(['/producto'], {
      relativeTo: this.activatedRouter
    })
  }

  guardar(): void {
    const producto = this.formProducto.getRawValue();
    producto.id = this.activatedRouter.snapshot.params['id']
    console.log(producto)
    this.productoService.update(producto).subscribe(x => {
      alert("Se actualizó correctamente");
      this.back();
    })

  }

  generateData(): void {
    this.productoService.getProductoID(this.activatedRouter.snapshot.params['id']).subscribe(x => {
      this.formProducto = this.formBuilder.group({
        id: [{ value: x.id, disabled: false }, [Validators.required]],
        name: [{ value: x.name, disabled: false }, [Validators.required]],
        precio_unitario: [{ value: x.precio_unitario, disabled: false }, [Validators.required]],
        categoria: [{ value: x.categoria, disabled: false }, [Validators.required]],
        proovedor: [{ value: x.proveedor, disabled: false }, [Validators.required]],
        cantidad: [{ value: x.cantidad, disabled: false }]
      })
    })
  }
}

