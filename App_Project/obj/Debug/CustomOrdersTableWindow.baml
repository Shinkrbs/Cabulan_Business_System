   M S B A M L   `   `   `  ����F  BApp_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:App_ProjectApp_Project  5   	   )    #App_Project.CustomOrdersTableWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:App_Project     5   	     � Title$  CustomOrdersTableWindow��5   	   $	��650��6)   $	��800��66   .��5
      � 
����ح�$��	0,0,-20,0q�6"    � ColumnDefinitions 5   
   �� 5      $	��87* �6   �� 5      $	��88* �6   .+�5   
   �� -   5        $
��Back��5      $��80��6    $��35��6+   
�������
���   �$
��Bold"�5   7   $��17(�6I   $��0q�5      $
��Left=�6%   $	��Top=�6@   $��	10,10,0,0q�6X   �� 5   
   
������� �� CornerRadius$ 15��6$    �� Padding$ 20q�66   $	��729��6C   $	��426��6O   $��Center=�5      $
��Left=�6,   $��2��6G   $��50,0,0,0q�6[    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6#      	Direction$	 270Q�61      ShadowDepth$ 5Q�6A      Opacity$	 0.3Q�6Q   ._�5      �� .+�5      �� $��Manage Custom Orders��6   $��24(�68   $
��Bold"�6F   $��Center=�5      $��	0,10,0,20q�69   &   System.Windows.Controls.DataGrid  5"      -   5        	  Name$	 OrdersDataGrid��5"      $	��550��63   $	��250��6?   $��10q�6L   
   AutoGenerateColumns
 .     HeadersVisibility$ Column=�5#   7      SelectionMode$ Single=�6R      
IsReadOnly .     CanUserAddRows .     Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ Product Description��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *ProductDescription+6q     5'      $ Price��6-   $	 150 6V    6<   �� *Price+6V     5(      $ Quantity��6-   $	 100 6\    6?   �� *
Quantity+6\   5*      �� 5-       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��10q�6S   .+�5.      �� -   5        $��Update Order��5.      $	��120��64   $��35��6@   ���#FFC107
���   �$
��Bold"�5/   E   $��14(�6W   $��0q�50      $��5q�61   �� 52      -   5        $��Delete Order��52      $	��120��64   $��35��6@   ���#DC3545
�������$
��Bold"�53   E   $��14(�6W   $��0q�54      $��5q�61   55      56      57      58      59      