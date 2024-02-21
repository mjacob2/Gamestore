import { Component } from '@angular/core';
import { MatBottomSheetRef } from '@angular/material/bottom-sheet';
import { PlatformsService } from '../../../services/platformsService';
import { NgForm } from '@angular/forms';

interface PlatformType {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-add-platform',
  templateUrl: './add-platform.component.html',
  styleUrls: ['./add-platform.component.css']
})
export class AddPlatformComponent {
  isLoading: boolean = false;
  errorMessage: string = '';
  platforms: PlatformType[] = [
    { value: 'Mobile', viewValue: 'Mobile' },
    { value: 'Browser', viewValue: 'Browser' },
    { value: 'Desktop', viewValue: 'Desktop' },
    { value: 'Console', viewValue: 'Console' }
  ];

  constructor(
    private bottomSheetRef: MatBottomSheetRef<AddPlatformComponent>,
    private httpPlatfomrsService: PlatformsService,
  ) { }

  async onSubmit(form: NgForm) {

    if (!form.valid) {
      this.errorMessage = "Fields marked red are obligatory"
    } else {
      this.errorMessage = ""
      this.isLoading = true;
      var platformToAdd = form.value;

      console.log(platformToAdd)

      try {
        await this.httpPlatfomrsService.addPlatform(platformToAdd);
        this.bottomSheetRef.dismiss({ event: 'platformAddedSuccesfully' });
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
