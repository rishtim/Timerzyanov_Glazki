   M S B A M L   `   `   `  ����M  ITimerzyanov_Glazki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Timerzyanov_GlazkiTimerzyanov_Glazki  5      &     Timerzyanov_Glazki.AgentSalePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Timerzyanov_Glazki     5      -   5          N� Title$!  Продажи агента��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,   .+�5   
   �� -   5        $��AddSale��5   ,   $%��Добавить позиции��6   $	��200��6Q   $��0��6]   �� 5   
   -   5        $��AgentSaleListView��5      $��1��6,   ��5      �� 5      .R�5      �  5      �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   .+�5!      ��  �� Orientation$ 
Horizontal=�6%   $��5q�6>   $��0��6I   $
��Left=�6V   .+�5"      �� $ ��Наименование: ��6(   $��20(�6>   �� 5#      $��20(�6?   ��6(   �� *Title+6?   5$      �� 5&      $ 
Horizontal=�6%   $��5q�6>   $��1��6I   $
��Left=�6V   .+�5'      �� $��Количество: ��6(   $��20(�6<   �� 5(      $��20(�6F   ��6(   �� *ProductCount+6F   5)      �� 5+      $ 
Horizontal=�6%   $��5q�6>   $��2��6I   $
��Left=�6V   .+�5,      �� $��
Дата: ��6(   $��20(�66   �� 5-      $��20(�6>   ��6(   �� *Date+6>   5.      �� 5/      $��DeleteSales��63   -   5        $��Удалить��5/   !   $��3��6`   $��Center=�6m   51      52      54      55      56      