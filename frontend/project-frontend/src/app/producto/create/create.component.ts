import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ProductoService } from "../../services/producto.service";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {

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
      cat_name: [{ value: null, disabled: false }, [Validators.required]],
      prov_name: [{ value: null, disabled: false }, [Validators.required]],
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
  }

  cancelar(): void {
    this.back();
  }

  back(): void {
    this.router.navigate(['..'], {
      relativeTo: this.activatedRouter
    })
  }

  guardar(): void {
    const producto = this.formProducto.getRawValue();
    console.log(producto)

    this.productoService.create(producto).subscribe(x => {
      alert('Se creo correctamente');
      this.back();
    })
  }

}
