@echo off
set cur_dir=%~dp0
set dest="%cur_dir%"..\UiTest_Data\Managed\
set test_files="%cur_dir%"Library\InterfaceUiTest.dll "%cur_dir%"Library\InterfaceUiTest.pdb "%cur_dir%"Library\UiTest.dll "%cur_dir%"Library\UiTest.pdb
(for %%f in (%test_files%) do ( 
   xcopy /y %%f %dest%.
))
start "" "%cur_dir%"..\UiTest.exe
