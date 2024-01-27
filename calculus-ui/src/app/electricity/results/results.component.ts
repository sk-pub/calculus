import { Component, Input } from '@angular/core';
import { environment } from '../../../environments/environment';
import { JsonApiRegistry } from 'api-registry';

const api = JsonApiRegistry.api('electricity-api', environment.apiUrl);
const calculateElectricity = api
  .endpoint('electricity', 'POST')
  .receives<{ yearlyConsumption: number }>()
  .returns<[ElectricityResult]>()
  .buildWithParse();

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrl: './results.component.scss'
})
export class ResultsComponent {
  @Input()
  set yearlyConsumption(yearlyConsumption: number) {
    this.getResults(yearlyConsumption);
  }

  results: ElectricityResult[] = [];

  async getResults(yearlyConsumption: number) {
    this.results = await calculateElectricity({ yearlyConsumption });
  }

  displayedColumns: string[] = ['name', 'annualCosts'];
}
