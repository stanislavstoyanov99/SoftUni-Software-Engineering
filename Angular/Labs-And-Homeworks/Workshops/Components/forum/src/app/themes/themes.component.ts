import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api-service';
import { ITheme } from '../models/ITheme';

@Component({
  selector: 'app-themes',
  templateUrl: './themes.component.html',
  styleUrls: ['./themes.component.scss']
})
export class ThemesComponent implements OnInit {

  themes: ITheme[] = [];
  errorFetcingData = false;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.loadThemes().subscribe({
      next: (data) => {
        this.themes = data;
      },
      error: (error) => {
        this.errorFetcingData = true;
        console.log(error);
      }
    });
  }

}
