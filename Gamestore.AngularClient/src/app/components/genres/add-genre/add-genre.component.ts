import { Component } from '@angular/core';
import { MatBottomSheetRef } from '@angular/material/bottom-sheet';
import { GenresService } from '../../../services/genresService';
import { NgForm } from '@angular/forms';
import { GetAllGenresModel } from '../../../../models/GetAllGenresModel';

@Component({
  selector: 'app-add-genre',
  templateUrl: './add-genre.component.html',
  styleUrls: ['./add-genre.component.css']
})
export class AddGenreComponent {
  isLoading: boolean = false;
  errorMessage: string = '';
  genres: GetAllGenresModel[] = [];

  constructor(
    private bottomSheetRef: MatBottomSheetRef<AddGenreComponent>,
    private httpGenresService: GenresService,
  ) { }

  async ngOnInit() {
    this.genres = await this.httpGenresService.getAllGenres();
  }

  async onSubmit(form: NgForm) {

    if (!form.valid) {
      this.errorMessage = "Fields marked red are obligatory"
    } else {
      this.errorMessage = ""
      this.isLoading = true;
      var genreToAdd = form.value;

      console.log(genreToAdd);

      try {
        await this.httpGenresService.addGenre(genreToAdd);
        this.bottomSheetRef.dismiss({ event: 'genreAddedSuccesfully' });
        this.isLoading = false;
      } catch (error: any) {
        this.isLoading = false;
        this.errorMessage = error.message;
      }
    }
  }

  closeBottomSheet(): void {
    this.bottomSheetRef.dismiss();
  }
}
