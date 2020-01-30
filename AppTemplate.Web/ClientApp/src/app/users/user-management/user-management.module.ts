import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { UsersListComponent } from './users-list/users-list.component';
import { NgxsModule } from '@ngxs/store';
import { UsersListState } from './users-list/users-list.state';

@NgModule({
  imports: [
    CommonModule,
    NgxsModule.forFeature([UsersListState]),
    MatTableModule,
    MatPaginatorModule,
    MatSortModule
  ],
  declarations: [UsersListComponent]
})
export class UserManagementModule { }
