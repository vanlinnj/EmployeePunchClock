   M S B A M L   `   `   `  ����H  DCourseProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CourseProjectCourseProject  5   	   '    !CourseProject.frmListAllEmployees   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CourseProject     5   	   -   5          � Title$  frmListAllEmployees��5   	   $��543.801��6%   $��884.38��66    � 	Resources 5	      *   $CourseProject.CourseProjectDBDataSet   courseProjectDBDataSet  tb_EmployeeViewSource �� Source �� Source��%\   &	        &	      7     5
   
   6'   �� 5   
    6=   �� *Tb_Employee+8   5      .��5      �  � DataContext# [ 6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5      $
��Left=�6%   $	��Top=�6@   $	��439��6X   $	��580��6e   $��
274,10,0,0q�6�   ��6q   �� 6�   �� 5   
   -   5         ��Name$ txtFirstName��5      $
��Left=�6(   $��23��6C   $��
135,32,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6�   $	��120��6�   ��6w   �� *SelectedItem.FirstName+ �� ElementName$ dataGrid��6�   �� 5   
   -   5        $ txtLastName��5      $
��Left=�6'   $��23��6B   $��
135,60,0,0q�6N   $
 Wrap=�6b   $	��Top=�6�   $	��120��6�   ��6v   �� *SelectedItem.LastName+$ dataGrid��6�   �� 5   
   -   5        $ txtSSN��5      $
��Left=�6"   $��23��6=   $��
135,88,0,0q�6I   $
 Wrap=�6]   $	��Top=�6�   $	��120��6�   ��6q   �� *SelectedItem.SSN+$ dataGrid��6�   �� 5   
   -   5        $ 
txtAddress��5      $
��Left=�6&   $��23��6A   $��135,116,0,0q�6M   $
 Wrap=�6b   $	��Top=�6�   $	��120��6�   ��6v   �� *SelectedItem.Address+$ dataGrid��6�   �� 5   
   -   5        $ txtCity��5      $
��Left=�6#   $��23��6>   $��135,144,0,0q�6J   $
 Wrap=�6_   $	��Top=�6�   $	��120��6�   ��6s   �� *SelectedItem.City+$ dataGrid��6�   �� 5   
   -   5        $ 	txtSearch��5      $
��Left=�6%   $��23��6@   $��109,344,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   5      5      