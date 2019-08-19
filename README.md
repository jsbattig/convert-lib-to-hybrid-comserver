# convert-lib-to-hybrid-comserver
Project that shows how to convert a regular .NET assembly into a hybrid one with a class working as a normal class and the other as a COM object living on a COM Surrogate process.

See following diff:

https://github.com/jsbattig/convert-lib-to-hybrid-comserver/commit/d3099944a74e0473a4f8b07d5bb92da2b65106f5

The next diff shows how support was added to pass and return a DTO object between the host application and the COM server:

https://github.com/jsbattig/convert-lib-to-hybrid-comserver/commit/cf8746225546a213d8c326ac82f95ab4a8711d7d

Please notice that the requirements to pass and/or return a DTO to/from a COM Server are:

1. The class must be a COM class itself
2. The module where the DTO COM class lives must be registered in the GAC, meaning it should be strong named as any COM module
3. The module must be declared as "library" rather than "server": [assembly:ApplicationActivation(ActivationOption::Library)];