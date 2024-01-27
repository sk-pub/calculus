import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ParametersComponent } from './parameters/parameters.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { ElectricityRoutingModule } from './electricity-routing.module';
import { ResultsComponent } from './results/results.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';

@NgModule({
  declarations: [
    ParametersComponent,
    ResultsComponent
  ],
  imports: [
    CommonModule,
    ElectricityRoutingModule,

    MatInputModule,
    MatFormFieldModule,
    FormsModule,
    MatIconModule,
    MatButtonModule,
    MatTableModule
  ],
  bootstrap: [ParametersComponent],
})
export class ElectricityModule { }
