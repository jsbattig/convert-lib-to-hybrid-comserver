$comCatalog = New-Object -ComObject COMAdmin.COMAdminCatalog
$appColl = $comCatalog.GetCollection("Applications")
$appColl.Populate()

$index = 0
foreach($app in $appColl) {
  if($app.Name -eq $args[0]) {
    $appColl.Remove($index)
    $appColl.SaveChanges()    
  }
  $index++
}