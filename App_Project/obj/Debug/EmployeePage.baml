   M S B A M L   `   `   `  ����F  BApp_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:App_ProjectApp_Project  5   	       App_Project.EmployeePage   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:App_Project     5   	     � Title$  EmployeePage��5   	   $	��640��6   $	��900��6+   
����ح�.��5
      � .+�5   
   �� -   5        $
��Back��5      $��80��6    $��35��6+   
�������
���   �$
��Bold"�5   7   $��14(�6I   $��0q�5      $
��Left=�6%   $	��Top=�6@   $��10q�6X   �� 5   
   
������� �� CornerRadius$ 15��6$    �� Padding$ 20q�66   $	��600��6C   $	��512��6O   $��Center=�5      $��Center=�6,    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6#      	Direction$	 270Q�61      ShadowDepth$ 5Q�6A      Opacity$	 0.3Q�6Q   ._�5      �� .+�5      �� $��Manage Employees��6   $��24(�64   $
��Bold"�6B   $��Center=�5      $��	0,10,0,20q�69   &   System.Windows.Controls.DataGrid  5      -   5          Name$ EmployeeDataGrid��5      $	��533��65   $	��300��6A   $��10q�6N   	   AutoGenerateColumns	 .  
   HeadersVisibility$
 Column=�5   7      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ Employee ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *EmpId+6\     5!      $
 Name��6-   $ * 6T    6;   �� *Name+6T     5"      $
 Role��6-   $ * 6T    6;   �� *Role+6T     5#      $ Contact Info��6-   $ * 6c    6C   �� *ContactInfo+6c   5%      �� 5(       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��10q�6S   .+�5)      �� -   5        $��Add Employee��5)      $	��120��64   $��40��6@   ���#0078D7
�������$
��Bold"�5*   E   $��15(�6W   $��0q�5+      $��5q�61   �� 5-      -   5        $��Update Employee��5-      $	��143��67   $��40��6C   ���#FFC107
���   �$
��Bold"�5.   E   $��15(�6W   $��0q�5/      $��5q�61   �� 51      -   5        $��Delete Employee��51      $	��140��67   $��40��6C   ���#DC3545
�������$
��Bold"�52   E   $��15(�6W   $��0q�53      $��5q�61   54      56      57      5:      5;      