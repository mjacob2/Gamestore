import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatBottomSheetRef } from '@angular/material/bottom-sheet';
import { PublishersService } from '../../../services/publishersService';

@Component({
  selector: 'app-add-publisher',
  templateUrl: './add-publisher.component.html',
  styleUrls: ['./add-publisher.component.css']
})
export class AddPublisherComponent {
  isLoading: boolean = false;
  errorMessage: string = '';

  constructor(
    private bottomSheetRef: MatBottomSheetRef<AddPublisherComponent>,
    private httpPublishersService: PublishersService,
  ) {}

  async onSubmit(form: NgForm) {

    if (!form.valid) {
      this.errorMessage = "Fields marked red are obligatory"
    } else {
      this.errorMessage = ""
      this.isLoading = true;
      var publisherToAdd = form.value;

      console.log(publisherToAdd)

      try {
        await this.httpPublishersService.addPublisher(publisherToAdd);
        this.bottomSheetRef.dismiss({ event: 'publisherAddedSuccesfully' });
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
