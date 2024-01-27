import { Routes } from '@angular/router';
import { ParametersComponent as ElectricityParametersComponent } from './electricity/parameters/parameters.component';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'electricity',
        loadChildren: () => import('./electricity/electricity.module').then(m => m.ElectricityModule)
    }
];
