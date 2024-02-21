import { Component, EventEmitter, Input, Output } from '@angular/core';
import { GetAllGenresModel } from '../../../../models/GetAllGenresModel';
import { GetAllPlatformsModel } from '../../../../models/GetAllPlatformsModel';
import { GetAllPublishersModel } from '../../../../models/GetAllPublishersModel';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { GenresService } from '../../../services/genresService';
import { PlatformsService } from '../../../services/platformsService';
import { PublishersService } from '../../../services/publishersService';
import { DisplayedFilters } from './displayedFilters';

@Component({
  selector: 'app-filtering-options',
  templateUrl: './filtering-options.component.html',
  styleUrls: ['./filtering-options.component.css']
})
export class FilteringOptionsComponent {
  @Input() displayedFilters!: DisplayedFilters;
  @Output() filter = new EventEmitter<string>();
  genres: GetAllGenresModel[] = [];
  platforms: GetAllPlatformsModel[] = [];
  publishers: GetAllPublishersModel[] = [];
  priceRange = [0, 500];
  range = new FormGroup({
    start: new FormControl<Date | null>(null),
    end: new FormControl<Date | null>(null),
  });


  constructor(
    private httpGenresService: GenresService,
    private httpPlatformsService: PlatformsService,
    private httpPublishersService: PublishersService,

  ) { }

  async ngOnInit() {
    this.genres = await this.httpGenresService.getAllGenres();
    this.platforms = await this.httpPlatformsService.getAllPlatforms();
    this.publishers = await this.httpPublishersService.getAllPublishers();
  }

  onSubmit(form: NgForm) {
    let queryString = '';

    if (form.value.filterName) {
      queryString += `&filterName=${form.value.filterName}`;
    }

    if (form.value.publisher) {
      form.value.publisher.forEach((pub: string) => {
        queryString += `&publisher=${pub}`;
      });
    }

    if (form.value.platform) {
      form.value.platform.forEach((plat: string) => {
        queryString += `&platform=${plat}`;
      });
    }

    if (form.value.genre) {
      form.value.genre.forEach((genre: string) => {
        queryString += `&genre=${genre}`;
      });
    }

    if (form.value.sortBy) {
      queryString += `&sortBy=${form.value.sortBy}`;
    }

    if (this.displayedFilters.priceRange) {
      queryString += `&minPrice=${this.priceRange[0]}&maxPrice=${this.priceRange[1]}`;
    }


    if (this.range.valid) {
      const startDateControl = this.range.get('start');
      const endDateControl = this.range.get('end');

      if (startDateControl?.value && endDateControl?.value) {
        const startDate = startDateControl.value.toISOString();
        const endDate = endDateControl.value.toISOString();
        queryString += `&startDate=${startDate}&endDate=${endDate}`;
      }
    }

    this.filter.emit(queryString);
  }

  resetRange() {
    this.range.reset();
  }
}
