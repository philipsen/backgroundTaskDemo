module Mqtt


open uPLibrary.Networking.M2Mqtt
open uPLibrary.Networking.M2Mqtt.Messages;
open System.Text

type Connection(env) =

    let node = MqttClient(brokerHostName="167.99.32.103")


    let msgReceived (e:MqttMsgPublishEventArgs) =
        let m = Encoding.ASCII.GetString e.Message
        printfn "Message: %A %s" e.Topic m

    do
        printfn("Start connection")
        node.MqttMsgPublishReceived.Add(msgReceived)
        node.Connect("fsharp_recv", "itho", "aapnootmies") |> ignore
        let topics = [| "#" |]
        let qos = [| MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE |]
        let sr = node.Subscribe(topics, qos)
        printfn "started: %A" sr