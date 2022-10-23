import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductoModule } from './producto/producto.module';

const routes: Routes = [

  {
    path: 'producto',
    loadChildren: () => import('./producto/producto.module').then((x => x.ProductoModule))
  }



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
