   M S B A M L   `   `   `  ����  PokemonLikeCsharp&     PokemonLikeCsharp.AddSpellWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$"  Ajouter des sorts au monstre��5   	   $	��582��5   	   $	��742��6   ���#f0f0f0 � 	Resources 5       �� 
TargetType �� Property �� Value   HeaderTextBlock��%  '��       &	  0    �� 5	   
   " ��6   .�5
      ��  � ��$ 5q�6'   �� 5       � ��$
 10,5q�6(   �� 5       � �� �#007ACC6+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � �� �#005A9E6,   �� 5       � ��$ 1q�60   5      �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 
10,0,10,10q�6'   �� 5       � �� �#3333336+   5      5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5"   
   �� $5��/Sélectionnez les sorts à ajouter au monstre :��6   #��[  6I   �� 5$   
   -   5        $��SpellsListBox��5$      $��1��6'   $��10q�64    �� DisplayMemberPath$
 Name��5%      
����������#CCCCCC$��1q�5(      5*      �� 5,   
   $��1��6   $��361,28,-341,0q�6"   $	��Top=�69   .+�5-      �� $��Description:��6   #��[  6,   �� 5.      -   5        $��SpellDescriptionTextBlock��5.      $4��.Sélectionnez un sort pour voir la description��69   $��	10,0,0,10q�6n   $
��Wrap=�6�   �� 5/      $��	Dégâts:��6   #��[  6'   �� 50      -   5        $��SpellDamageTextBlock��50      $2��,Sélectionnez un sort pour voir les dégâts��64   $��	10,0,0,10q�6e   51      �� 53   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�54      �� -   5        $��CancelButton��54      $��Annuler��6)   $	��120��6O   55      56      57      